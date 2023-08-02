using System;
using System.Collections;
using System.Collections.Generic;
// using concursInot.Entities;

namespace concursInot;

public class Service
{
    private AngajatiDatabaseRepository repo_angajati;
    private PersoaneDatabaseRepository repo_persoane;
    private ParticipantiDatabaseRepository repo_participanti;

    public Service(AngajatiDatabaseRepository repoAng, PersoaneDatabaseRepository repoPers, ParticipantiDatabaseRepository repoPart)
    {
        repo_angajati = repoAng;
        repo_persoane = repoPers;
        repo_participanti = repoPart;
    }


    
    public Angajat getAngajatByEmailAndPassword(string email, string password)
    {
        return repo_angajati.findOneByEmailAndPassword(email,password);
    }

    public Angajat getAngajatByEmail(string email)
    {
        return repo_angajati.findOneByEmail(email);
    }
    
    
    
    
    
    
    
    public long getNewPersoanaId()
    {
        return repo_persoane.getNewId();
    }

    public void addPersoana(Persoana p)
    {
        repo_persoane.save(p);
    }
    
    
    
    
    
    
    public long getNewParticipantId()
    {
        return repo_participanti.getNewId();
    }


    public int getNumarParticipantiDupaProba(string stil,string distanta)
    {
        return repo_participanti.getNumarParticipantiDupaProba(stil,distanta);
    }

    

    public ArrayList getParticipanti()
    {
        Dictionary<long,Participant> participanti=repo_participanti.findAll();
        Dictionary<long,Persoana> persoane=repo_persoane.findAll();
        Persoana person;
        var lista_participanti=new ArrayList();
        foreach(var p in participanti.Values)
        {
            person=persoane[p.getIdPersoana()];
            lista_participanti.Add(new ParticipantDTO(person.getNume(),person.getVarsta(),
                p.getStil().ToString(),p.getDistanta().ToString()));
        }
        return lista_participanti;
    }
    
    
    
    public ArrayList getSearchedParticipanti(string stil,string distanta)
    {
        Dictionary<long,Participant> participanti=repo_participanti.findAllByCompetition(stil,distanta);
        Dictionary<long,Persoana> persoane=repo_persoane.findAll();
        Persoana person;
        var lista_participanti=new ArrayList();
        foreach(var p in participanti.Values)
        {
            person=persoane[p.getIdPersoana()];
            lista_participanti.Add(new ParticipantDTO(person.getNume(),person.getVarsta(),
                p.getStil().ToString(),p.getDistanta().ToString()));
        }
        return lista_participanti;
    }



    public bool inscriereParticipant(string nume, int varsta, string stil, string distanta)
    {
        //de verificat daca participantul exista deja
        //probleme la findOne in Participanti
        //de verificat daca se adauga un participant duplicat
        Persoana pers=repo_persoane.findOneByNumeAndVarsta(nume,varsta);
        if(pers==null)
        {
            pers=new Persoana(nume,varsta);
            pers.Id=getNewPersoanaId();
            addPersoana(pers);
        }
        Participant part = repo_participanti.findParticipantByIdAndCompetition(pers.Id, stil, distanta);
        if (part != null) 
            return false; 
        Participant p=new Participant(pers.Id,(Distanta)Enum.Parse(typeof(Distanta),distanta),(Stil)Enum.Parse(typeof(Stil),stil));
        p.Id=getNewParticipantId();
        repo_participanti.save(p);
        return true;
    }
    
}