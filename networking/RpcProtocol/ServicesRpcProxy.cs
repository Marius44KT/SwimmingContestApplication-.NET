using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Xml.Serialization;
using services;

namespace networking.rpcprotocol;

public class ServicesRpcProxy:IServices
{
    private string host;
    private int port;
    private Queue<Response> responses;
    private EventWaitHandle _waitHandle;
    
    private IFormatter formatter;
    private TcpClient connection;
    private NetworkStream stream;
    
    private volatile bool finished;
    private IObserver client;

    public ServicesRpcProxy(string host, int port)
    {
        this.host = host;
        this.port = port;
        responses=new Queue<Response>();
    }
    
    
    
    public bool login(string data, string password, IObserver client)
    {
        initializeConnection();
        Angajat angajat=new Angajat(data,password);
        Request request = new Request.Builder().type(RequestType.LOGIN).data(angajat).build();
        sendRequest(request);
        Response response = readResponse();

        Boolean loggedIn = false;

        if (response.Type == ResponseType.OK) {
            loggedIn = (Boolean) response.Data;
            if (loggedIn) {
                this.client = client;
                return true;
            }
        } else if (response.Type == ResponseType.ERROR)
        {
            string err = response.Data.ToString();
            closeConnection();
            throw new ConcursException(err);
        }
        return loggedIn;
    }

    
    
    public List<ParticipantDTO> getParticipanti()
    {
        Request req = new Request.Builder().type(RequestType.GET_PARTICIPANTS).build();
        sendRequest(req);
        Response response = readResponse();
        if (response.Type == ResponseType.ERROR) {
            String err = response.Data.ToString();
            throw new ConcursException(err);
        }
        List<ParticipantDTO> participanti=(List<ParticipantDTO>)response.Data;
        return participanti;
    }

    
    
    public List<ParticipantDTO> getSearchedParticipanti(string stil, string distanta)
    {
        Request req=new Request.Builder().type(RequestType.GET_CONTEST_PARTICIPANTS).data(stil+" "+distanta).build();
        sendRequest(req);
        Response response = readResponse();
        if (response.Type == ResponseType.ERROR) {
            String err = response.Data.ToString();
            throw new ConcursException(err);
        }
        List<ParticipantDTO> participanti=(List<ParticipantDTO>)response.Data;
        return participanti;
    }
    
    
    
    public List<int> getNumarParticipantiDupaProba()
    {
        Request req = new Request.Builder().type(RequestType.GET_NUMBER_OF_PARTICIPANTS).build();
        sendRequest(req);
        Response response = readResponse();
        if (response.Type == ResponseType.ERROR) {
            String err = response.Data.ToString();
            throw new ConcursException(err);
        }
        return (List<int>)response.Data;
    }

    
    
    public void inscriereParticipant(string nume, int varsta, string stil, string distanta)
    {
        ParticipantDTO participantDTO=new ParticipantDTO(nume,varsta,stil,distanta);
        Request req = new Request.Builder().type(RequestType.ADD_PARTICIPANT).data(participantDTO).build();
        sendRequest(req);
        Response response = readResponse();
        if (response.Type == ResponseType.ERROR) {
            String err = response.Data.ToString();
            throw new ConcursException(err);
        }
    }

    

    public void logout(string email)
    {
        Angajat angajat=new Angajat(email,null);
        Request req = new Request.Builder().type(RequestType.LOGOUT).data(angajat).build();
        sendRequest(req);
        Response response = readResponse();
        closeConnection();
        client = null;
        if (response.Type == ResponseType.ERROR)
        {
            String err = response.Data.ToString();
            throw new ConcursException(err);
        }
    }
    
    
    
    private void closeConnection()
    {
        finished = true;
        try
        {
            stream.Close();
            connection.Close();
            client = null;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.StackTrace);
        }

    }

        
    private void sendRequest(Request request)
    {
        try
        {
            formatter.Serialize(stream, request);
            stream.Flush();
        }
        catch (Exception e)
        {
            throw new ConcursException("Error sending object " + e);
        }

    }

    
    
    private Response readResponse()
    {
        Response response = null;
        try
        {
            _waitHandle.WaitOne();
            lock (responses)
            {
                response = responses.Dequeue();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.StackTrace);
        }
        return response;
    }

    
    private void initializeConnection()
    {
        try
        {
            connection = new TcpClient(host, port);
            stream = connection.GetStream();
            formatter = new BinaryFormatter();
            finished = false;
            _waitHandle = new AutoResetEvent(false);
            startReader();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.StackTrace);
        }
    }

    
    private void startReader()
    {
        Thread tw = new Thread(run);
        tw.Start();
    }

    
    
    public void run()
    {
        while (!finished)
        {
            try
            {
                Response response = (Response)formatter.Deserialize(stream);
                Console.WriteLine("response received " + response);
                if (response.Type == ResponseType.UPDATE)
                {
                    client.participantInscris();
                }
                else
                {
                    lock (responses)
                    {
                        responses.Enqueue((Response)response);
                    }
                    _waitHandle.Set();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Reading error " + e);
            }

        }
    }
}