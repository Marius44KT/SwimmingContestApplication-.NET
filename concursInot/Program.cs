using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
// using concursModel.Entities;
using log4net;
using Microsoft.Extensions.Configuration;

namespace concursInot
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("C:\\Users\\Marius Andreiasi\\RiderProjects\\concursInot\\concursInot\\config.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();
            string connectionString=configuration.GetConnectionString("MyConnectionString");
            //Console.WriteLine(connectionString);
            log4net.Config.XmlConfigurator.Configure();
            
            ILog logger1 = LogManager.GetLogger("repo_angajati");
            AngajatiDatabaseRepository repo_angajati = new AngajatiDatabaseRepository(connectionString, logger1);
            ILog logger2 = LogManager.GetLogger("repo_persoane");
            PersoaneDatabaseRepository repo_persoane = new PersoaneDatabaseRepository(connectionString,logger2);
            ILog logger3 = LogManager.GetLogger("repo_participanti");
            ParticipantiDatabaseRepository repo_participanti = new ParticipantiDatabaseRepository(connectionString,logger3);

            Service service = new Service(repo_angajati, repo_persoane, repo_participanti);
            Application.Run(new loginForm(service));


            // Persoana p1 = new Persoana("Marius", 21);
            // p1.Id = 0; repo_persoane.save(p1);
            // Persoana p2 = new Persoana("Denis", 20);
            // p2.Id = 1;
            // repo_persoane.save(p2);
            // Persoana p3 = new Persoana("Andrei", 20);
            // p3.Id = 2;
            // repo_persoane.save(p3);



            // Participant pr1 = new Participant(0l,(Distanta)Enum.Parse(typeof(Distanta),"dist800m"), (Stil)Enum.Parse(typeof(Stil),"flutur"));
            // pr1.Id = 0; repo_participanti.save(pr1);
            // Participant pr2 = new Participant(0l,(Distanta)Enum.Parse(typeof(Distanta),"dist1500m"), (Stil)Enum.Parse(typeof(Stil),"mixt"));
            // pr2.Id = 1; repo_participanti.save(pr2);
            // Participant pr3 = new Participant(1l,(Distanta)Enum.Parse(typeof(Distanta),"dist200m"), (Stil)Enum.Parse(typeof(Stil),"spate"));
            // pr3.Id = 2; repo_participanti.save(pr3);

            // Dictionary<long, Participant> concurenti = new Dictionary<long, Participant>();
            // concurenti = repo_participanti.findAllByCompetition("dist800m", "flutur");
            // foreach (KeyValuePair<long, Participant> entry in concurenti)
            // {
            //     Console.WriteLine(entry.Value.Id+" "+entry.Value.getDistanta()+" "+entry.Value.getStil());
            // }
        }
    }
}