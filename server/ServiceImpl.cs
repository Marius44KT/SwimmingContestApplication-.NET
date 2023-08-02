using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using services;

namespace concursInot;

public class ServiceImpl:IServices
{
    private AngajatiIRepository<long,Angajat> repo_angajati;
    private PersoaneIRepository<long, Persoana> repo_persoane;
    private ParticipantiIRepository<long, Participant> repo_participanti;

    private ConcurrentDictionary<string, IObserver> loggedClients;
    private int defaultThreadsNo=5;


    public ServiceImpl(AngajatiIRepository<long, Angajat> repo_angajati, PersoaneIRepository<long, Persoana>
        repo_persoane, ParticipantiIRepository<long, Participant> repo_participanti)
    {
        this.repo_angajati = repo_angajati;
        this.repo_persoane = repo_persoane;
        this.repo_participanti = repo_participanti;
        loggedClients=new ConcurrentDictionary<string, IObserver>();
    }

    
    public long getNewPersoanaId() { return repo_persoane.getNewId(); }

    public void addPersoana(Persoana p) { repo_persoane.save(p); }


    public long getNewParticipantId() { return repo_participanti.getNewId(); }
    
    
    public bool login(string email, string password, IObserver client)
    {
        Angajat a = repo_angajati.findOneByEmailAndPassword(email, password);
        if (a!=null)
        {
            if (loggedClients.ContainsKey(a.getEmail()))
                throw new ConcursException("User already logged in.");
            loggedClients[email] = client;
            return true;
        }
        return false;
    }

    
    
    public List<ParticipantDTO> getParticipanti()
    {
        Dictionary<long, Participant> participanti=repo_participanti.findAll();
        Dictionary<long, Persoana> persoane=repo_persoane.findAll();
        Participant concurent; Persoana individ;
        List<ParticipantDTO> lista_participanti = new List<ParticipantDTO>();
        foreach(KeyValuePair<long, Participant> p in participanti)
        {
            concurent = p.Value;
            persoane.TryGetValue(concurent.getIdPersoana(), out individ);
            lista_participanti.Add(new ParticipantDTO(individ.getNume(),individ.getVarsta(),
                concurent.getStil().ToString(),concurent.getDistanta().ToString()));
        }
        return lista_participanti;
    }

    
    public List<ParticipantDTO> getSearchedParticipanti(string stil, string distanta)
    {
        Dictionary<long,Participant> participanti=repo_participanti.findAllByCompetition(stil,distanta);
        Dictionary<long,Persoana> persoane=repo_persoane.findAll();
        Participant concurent; Persoana individ;
        List<ParticipantDTO> lista_participanti=new List<ParticipantDTO>();
        foreach(KeyValuePair<long,Participant> p in participanti)
        {
            concurent = p.Value;
            persoane.TryGetValue(concurent.getIdPersoana(), out individ);
            lista_participanti.Add(new ParticipantDTO(individ.getNume(),individ.getVarsta(),
                concurent.getStil().ToString(),concurent.getDistanta().ToString()));
        }
        return lista_participanti;
    }

    
    public List<int> getNumarParticipantiDupaProba()
    {
        String[] styles={"liber","spate","flutur","mixt"};
        String[] distances= {"dist50m","dist200m","dist800m","dist1500m"};
        List<int> valori=new List<int>();
        foreach (String stil in styles)
        {
            Console.WriteLine(stil);
            foreach (String distanta in distances)
                valori.Add(repo_participanti.getNumarParticipantiDupaProba(stil, distanta));
        }
        Console.WriteLine(valori.Count);
        return valori;
    }

    
    
    public void inscriereParticipant(string nume, int varsta, string stil, string distanta)
    {
        //de verificat daca participantul exista deja
        Persoana pers=repo_persoane.findOneByNumeAndVarsta(nume,varsta);
        if(pers==null)
        {
            pers=new Persoana(nume,varsta);
            pers.Id=getNewPersoanaId();
            addPersoana(pers);
        }
        Participant part = repo_participanti.findParticipantByIdAndCompetition(pers.Id, stil, distanta);
        if (part != null)
            return;
        Participant p=new Participant(pers.Id,(Distanta)Enum.Parse(typeof(Distanta),distanta),(Stil)Enum.Parse(typeof(Stil),stil));
        p.Id=getNewParticipantId();
        repo_participanti.save(p);
        foreach(var client in loggedClients)
        {
            IObserver observer = client.Value;
            String email = client.Key;
            Console.WriteLine("Notifying [" + email + "] about new participant.");
            Task.Run(() => observer.participantInscris());
        }
    }

    

    public void logout(string email)
    {
        IObserver localClient;
        loggedClients.TryRemove(email, out localClient);
        if (localClient==null)
            throw new ConcursException("User " + email + " is not logged in.");
    }
}