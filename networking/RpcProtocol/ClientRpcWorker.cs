using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.AccessControl;
using System.Threading;
using services;

namespace networking.rpcprotocol;

public class ClientRpcWorker:IObserver
{
    private IServices server;
    private TcpClient connection;

    private NetworkStream stream;
    private IFormatter formatter;
    private volatile bool connected;
    public ClientRpcWorker(IServices server, TcpClient connection)
    {
        this.server = server;
        this.connection = connection;
        try
        {
            stream=connection.GetStream();
            formatter = new BinaryFormatter();
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
                Object request=formatter.Deserialize(stream);
                Response response=handleRequest((Request)request);
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

    
    private Response handleRequest(Request request)
    {
        Response response = null;
        switch (request.Type)
        {
            case RequestType.LOGIN:
                response=solveLogin(request);
                break;
            case RequestType.LOGOUT:
                response=solveLogout(request);
                break;
            case RequestType.GET_PARTICIPANTS:
                response = solveGetParticipanti(request);
                break;
            case RequestType.GET_CONTEST_PARTICIPANTS:
                response = solveGetSearchedParticipanti(request);
                break;
            case RequestType.GET_NUMBER_OF_PARTICIPANTS:
                response = solveNumberOfParticipants(request);
                break;
            case RequestType.ADD_PARTICIPANT:
                response = solveInscriereParticipant(request);
                break;
        }
        return response;
    }

    
    
    private Response solveLogin(Request request)
    {
        Angajat angajat = (Angajat)request.Data;
        String email = angajat.getEmail();
        String password = angajat.getParola();
        try
        {
            bool loggedIn;
            lock (server)
            {
                loggedIn = server.login(email, password, this);
            }
            return new Response.Builder().type(ResponseType.OK).data(loggedIn).build();
        }
        catch (ConcursException e)
        {
            connected = false;
            return new Response.Builder().type(ResponseType.ERROR).data(e.Message).build();
        }
    }

    
    
    private Response solveGetParticipanti(Request request)
    {
        try
        {
            List<ParticipantDTO> participanti;
            lock (server)
            {
                participanti = server.getParticipanti();
            }
            return new Response.Builder().type(ResponseType.OK).data(participanti).build();
        } catch (ConcursException e) {
            return new Response.Builder().type(ResponseType.ERROR).data(e.Message).build();
        }
    }
    
    
    
    private Response solveGetSearchedParticipanti(Request request)
    {
        String stil_distanta=request.Data.ToString();
        string[] parts = stil_distanta.Split(' ');
        String stil=parts[0],distanta=parts[1];
        try
        {
            List<ParticipantDTO> participanti;
            lock (server)
            {
                participanti = server.getSearchedParticipanti(stil, distanta);
            }
            return new Response.Builder().type(ResponseType.OK).data(participanti).build();
        } catch (ConcursException e) {
            return new Response.Builder().type(ResponseType.ERROR).data(e.Message).build();
        }
    }
    
    
    
    private Response solveNumberOfParticipants(Request request)
    {
        try
        {
            List<int> result;
            lock (server)
            {
                result = server.getNumarParticipantiDupaProba();
            }
            return new Response.Builder().type(ResponseType.OK).data(result).build();
        } catch (ConcursException e) {
            return new Response.Builder().type(ResponseType.ERROR).data(e.Message).build();
        }
    }
    
    
    
    private Response solveInscriereParticipant(Request request)
    {
        ParticipantDTO p=(ParticipantDTO) request.Data;
        try
        {
            lock (server)
            {
                server.inscriereParticipant(p.getNume(), p.getVarsta(), p.getStil(), p.getDistanta());
            }
            return new Response.Builder().type(ResponseType.OK).build();
        } catch (ConcursException e) {
            return new Response.Builder().type(ResponseType.ERROR).data(e.Message).build();
        }
    }
    
    
    
    private Response solveLogout(Request request)
    {
        Angajat angajat = (Angajat) request.Data;
        String email= angajat.getEmail();
        try {
            lock (server)
            {
                server.logout(email);
            }
            connected = false;
            return new Response.Builder().type(ResponseType.OK).data(true).build();
        } catch (ConcursException e) {
            return new Response.Builder().type(ResponseType.ERROR).data(e.Message).build();
        }
    }
    
    
    
    private void sendResponse(Response response)
    {
        Console.WriteLine("sending response "+response);
        lock (stream)
        {
            formatter.Serialize(stream, response);
            stream.Flush();
        }
    }

    
    
    public void participantInscris()
    {
        Response resp = new Response.Builder().type(ResponseType.UPDATE).build();
        Console.WriteLine("Participant added");
        try
        {
            sendResponse(resp);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.StackTrace);
        }
    }
}