using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
// using concursModel.Entities;
using log4net;
using Microsoft.Extensions.Configuration;
using networking.servers;
using services;

namespace concursInot;

// public class StartRpcServer
// {
//     private static int defaultPort = 55555;
//     private static string defaultHost = "127.0.0.1";
//
//     static void Main(string[] args)
//     {
//         Application.EnableVisualStyles();
//         Application.SetCompatibleTextRenderingDefault(false);
//         var builder = new ConfigurationBuilder()
//             .SetBasePath(Directory.GetCurrentDirectory())
//             .AddJsonFile("C:\\Users\\Marius Andreiasi\\RiderProjects\\concursInot\\clientWF\\config.json", optional: true, reloadOnChange: true);
//         IConfigurationRoot configuration = builder.Build();
//         string connectionString=configuration.GetConnectionString("MyConnectionString");
//         //Console.WriteLine(connectionString);
//         log4net.Config.XmlConfigurator.Configure();
//         
//         ILog logger1 = LogManager.GetLogger("repo_angajati");
//         AngajatiDatabaseRepository repo_angajati = new AngajatiDatabaseRepository(connectionString,logger1);
//
//         ILog logger2 = LogManager.GetLogger("repo_persoane");
//         PersoaneDatabaseRepository repo_persoane = new PersoaneDatabaseRepository(connectionString,logger2);
//
//         ILog logger3=LogManager.GetLogger("repo_participanti");
//         ParticipantiDatabaseRepository repo_participanti = new ParticipantiDatabaseRepository(connectionString,logger3);
//
//         
//         IServices ServerImpl = new ServiceImpl(repo_angajati, repo_persoane, repo_participanti);
//         AbstractServer server = new RpcConcurrentServer(defaultHost,defaultPort, ServerImpl);
//         try
//         {
//             server.Start();
//             Console.WriteLine("Server started...");
//         }
//         catch (ServerException e)
//         {
//             Console.Error.WriteLine("Error starting the server" + e.Message);
//         }
//     }
// }
//
