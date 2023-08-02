using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using concursInot;
using networking.rpcprotocol;
using services;



namespace ConcursInot.ClientFX
{
    public class StartRpcClientFX
    {
        private static int defaultPort = 55555;
        private static string defaultServer = "127.0.0.1";

        static void Main()
        {
            Console.WriteLine("In client start");
            Dictionary<string, string> clientProps = new Dictionary<string, string>();
            try
            {
                string[] lines = File.ReadAllLines(@"C:\Users\Marius Andreiasi\RiderProjects\concursInot\clientWF\appclient.properties");
                foreach (string line in lines)
                {
                    int idx = line.IndexOf('=');
                    if (idx >= 0)
                    {
                        string key = line.Substring(0, idx).Trim();
                        string value = line.Substring(idx + 1).Trim();
                        clientProps[key] = value;
                    }
                }
                Console.WriteLine("Client props set.");
                foreach (var kvp in clientProps)
                {
                    Console.WriteLine(kvp.Key + "=" + kvp.Value);
                }
            }
            catch (IOException e)
            {
                Console.Error.WriteLine("CANNOT FIND appclient.properties" + e);
                return;
            }
            string serverIP;
            int serverPort;
            
            try
            {
                serverIP = clientProps["server.host"];
                serverPort = Int32.Parse(clientProps["server.port"]);
            }catch (FormatException ex){
                Console.Error.WriteLine("Conversion not possible");
                serverIP = defaultServer;
                serverPort = defaultPort;
            }
            // MessageBox.Show("Using server IP " + serverIP+" "+serverPort);
            
            IServices server = new ServicesRpcProxy(serverIP, serverPort);
            Application.Run(new loginForm(server));
        }
    }
}