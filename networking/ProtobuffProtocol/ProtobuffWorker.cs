using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using Com.Example;
using Google.Protobuf;
using networking.rpcprotocol;
using services;

namespace networking.ProtobuffProtocol;

public class ProtobuffWorker:IObserver
{
    private IServices server;
    private TcpClient connection;

    private NetworkStream stream;
    private volatile bool connected;
    public ProtobuffWorker(IServices server, TcpClient connection)
    {
        this.server = server;
        this.connection = connection;
        try
        {
            stream=connection.GetStream();
            connected=true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.StackTrace);
        }
    }

    
    public virtual void run()
    {
        while(connected)
        {
            try
            {
                RequestP request = RequestP.Parser.ParseDelimitedFrom(stream);
                ResponseP response = handleRequest(request);
                if (response!=null)
                {
                    sendResponse(response);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
				
            try
            {
                Thread.Sleep(1000);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
        try
        {
            stream.Close();
            connection.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Error "+e);
        }
    }

    
    private ResponseP handleRequest(RequestP request)
    {
        ResponseP response = null;
        switch (request.Type)
        {
            case RequestP.Types.Type.Login:
                response=solveLogin(request);
                break;
            case RequestP.Types.Type.Logout:
                response=solveLogout(request);
                break;
            case RequestP.Types.Type.GetParticipants:
                response = solveGetParticipanti(request);
                break;
            case RequestP.Types.Type.GetContestParticipants:
                response = solveGetSearchedParticipanti(request);
                break;
            case RequestP.Types.Type.GetNumberOfParticipants:
                response = solveNumberOfParticipants(request);
                break;
            case RequestP.Types.Type.AddParticipant:
                response = solveInscriereParticipant(request);
                break;
        }
        return response;
    }

    
    
    private ResponseP solveLogin(RequestP request)
    {
        AngajatP angajatP = request.Angajat;
        Angajat angajat=new Angajat(angajatP.Email,angajatP.Parola);
        String email = angajat.getEmail();
        String password = angajat.getParola();
        try
        {
            lock (server)
            {
                bool loggedIn=server.login(email, password, this);
                return ProtoUtils.createLoginResponse(loggedIn);
            }
        }
        catch (ConcursException e)
        {
            connected = false;
            return ProtoUtils.createErrorResponse(e.Message);
        }
    }

    
    
    private ResponseP solveGetParticipanti(RequestP request)
    {
        try
        {
            List<ParticipantDTO> participanti;
            lock (server)
            {
                participanti=server.getParticipanti();
            }
            return ProtoUtils.createGetParticipantiResponse(participanti);
        } catch (ConcursException e) {
            return ProtoUtils.createErrorResponse(e.Message);
        }
    }
    
    
    
    private ResponseP solveGetSearchedParticipanti(RequestP request)
    {
        String stil_distanta = request.Str;
        string[] parts = stil_distanta.Split(' ');
        String stil=parts[0],distanta=parts[1];
        try
        {
            List<ParticipantDTO> participanti;
            lock (server)
            {
                participanti = server.getSearchedParticipanti(stil, distanta);
                return ProtoUtils.createGetSearchedParticipantiResponse(participanti);
            }
        } catch (ConcursException e) {
            return ProtoUtils.createErrorResponse(e.Message);
        }
    }
    
    
    
    private ResponseP solveNumberOfParticipants(RequestP request)
    {
        try
        {
            List<int> result;
            lock (server)
            {
                result = server.getNumarParticipantiDupaProba();
                return ProtoUtils.createGetNumberOfParticipantsResponse(result);
            }
        } catch (ConcursException e) {
            return ProtoUtils.createErrorResponse(e.Message);
        }
    }
    
    
    
    private ResponseP solveInscriereParticipant(RequestP request)
    {
        ParticipantDTOP p= request.ParticipantDTO;
        try
        {
            lock (server)
            {
                server.inscriereParticipant(p.Nume, p.Varsta, p.Stil, p.Distanta);
            }
            return ProtoUtils.createOkResponse();
        } catch (ConcursException e)
        {
            return ProtoUtils.createErrorResponse(e.Message);
        }
    }
    
    
    
    private ResponseP solveLogout(RequestP request)
    {
        AngajatP angajatP = request.Angajat;
        Angajat angajat=new Angajat(angajatP.Email,angajatP.Parola);
        String email = angajat.getEmail();
        try {
            lock (server)
            {
                server.logout(email);
            }
            connected = false;
            return ProtoUtils.createOkResponse();
        } catch (ConcursException e)
        {
            return ProtoUtils.createErrorResponse(e.Message);
        }
    }
    
    
    
    private void sendResponse(ResponseP response)
    {
        Console.WriteLine("sending response "+response);
        lock (stream)
        {
            response.WriteDelimitedTo(stream);
            stream.Flush();
        }
    }

    
    
    public void participantInscris()
    {
        ResponseP response = ProtoUtils.createUpdateResponse();
        Console.WriteLine("Participant added");
        try
        {
            sendResponse(response);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.StackTrace);
        }
    }
}