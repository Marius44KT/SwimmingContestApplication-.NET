using System;
using System.Net.Sockets;
using System.Threading;
using networking.ProtobuffProtocol;
using networking.rpcprotocol;
using networking.servers;
using services;

public class RpcConcurrentServer : AbsConcurrentServer
{
    private IServices server;
    
    
    public RpcConcurrentServer(string host,int port,IServices s) : base(host,port)
    {
        server=s;
        Console.WriteLine("RpcConcurrentServer");
    }

    
    protected override Thread createWorker(TcpClient client)
    {
        ClientRpcWorker worker = new ClientRpcWorker(server, client);
        // ProtobuffWorker worker = new ProtobuffWorker(server, client);
        return new Thread(new ThreadStart(worker.run));
    }
}