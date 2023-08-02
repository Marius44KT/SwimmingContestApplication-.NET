using System;
using System.Collections.Generic;
using System.Data.SqlClient;
// using concursInot.Entities;
using System.Data.SqlClient;
using concursInot;
using log4net;
using log4net.Repository.Hierarchy;
using Npgsql;

public class ParticipantiDatabaseRepository : ParticipantiIRepository<long, Participant>
{
    private string url;
    private ILog log;

    public ParticipantiDatabaseRepository(string url,ILog logger)
    {
        this.url = url;
        this.log = logger;
        log.Info("Creating ParticipantiDatabaseRepository");
    }
    
    
    public Participant findOne(long id)
    {
        log.Info("Executing findOne");
        string sql = "SELECT * from participanti where id=@id";
        try
        {
            using var connection = new NpgsqlConnection(url);
            using var command = new NpgsqlCommand(sql,connection);
            {
                connection.Open();
                command.Parameters.AddWithValue("@id", id);
                NpgsqlDataReader reader=command.ExecuteReader();
                if (reader.Read())
                {
                    long idPersoana = reader.GetInt64(reader.GetOrdinal("idpersoana"));
                    string distanta = reader.GetString(reader.GetOrdinal("distanta"));
                    string stil = reader.GetString(reader.GetOrdinal("stil"));
                    // Participant p = new Participant(nume, varsta);
                    Participant p = new Participant(idPersoana, (Distanta)Enum.Parse(typeof(Distanta),distanta), (Stil)Enum.Parse(typeof(Stil),stil));
                    p.Id = id;
                    log.Info("Execution ended succesfully");
                    return p;
                }
                return null;
            }
        }
        catch (NpgsqlException e)
        {
            log.Error("There was a problem with findOne.");
            return null;
        }
    }
    
    
    
    public Dictionary<long, Participant> findAll()
    {
        log.Info("Executing findAll");
        Dictionary<long,Participant> probe = new Dictionary<long, Participant>();
        string sql="SELECT * from participanti";
        try
        {
            using var connection = new NpgsqlConnection(url);
            using var command = new NpgsqlCommand(sql, connection);
            {
                connection.Open();
                NpgsqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    long id = reader.GetInt64(reader.GetOrdinal("id"));
                    long idPersoana = reader.GetInt64(reader.GetOrdinal("idpersoana"));
                    string distanta = reader.GetString(reader.GetOrdinal("distanta"));
                    string stil = reader.GetString(reader.GetOrdinal("stil"));

                    Participant p = new Participant(idPersoana, (Distanta)Enum.Parse(typeof(Distanta),distanta), (Stil)Enum.Parse(typeof(Stil),stil));
                    p.Id = id;
                    probe.Add(id, p);
                }
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.ToString());
            log.Error("There was a problem with findAll.");
            return null;
        }
        log.Info("findAll was successfully executed");
        return probe;
    }
    
    
    
    
    public bool save(Participant proba)
    {
        log.Info("Executing save");
        string sql="INSERT INTO participanti (id, idpersoana, distanta, stil) VALUES (@Id, @IdPersoana, @Distanta, @Stil)";
        try
        {
            using var connection = new NpgsqlConnection(url);
            using var command = new NpgsqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Id", proba.Id);
            command.Parameters.AddWithValue("@IdPersoana", proba.getIdPersoana());
            command.Parameters.AddWithValue("@Distanta", proba.getDistanta().ToString());
            command.Parameters.AddWithValue("@Stil", proba.getStil().ToString());
    
            connection.Open();
            command.ExecuteNonQuery();
            log.Info("save was succesfully executed.");
            return true;
        }
        catch (NpgsqlException e)
        {
            log.Error("There was a problem with save.");
            return false;
        }
    }

    
    
    public bool delete(long idPersoana)
    {
        log.Info("Executing delete");
        string sql = "DELETE FROM participanti WHERE id = @Id";
        try
        {
            using var connection = new NpgsqlConnection(url);
            using var command = new NpgsqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Id", idPersoana);
    
            connection.Open();
            command.ExecuteNonQuery();
            log.Info("delete was succesfully executed.");
            return true;
        }
        catch (NpgsqlException e)
        {
            log.Error("There was a problem with delete.");
            return false;
        }
    }

    
    
    public bool update(Participant participant)
    {
        log.Info("Executing update");
        string sql = "UPDATE participanti SET idpersoana=@IdPersoana, distanta = @Distanta, stil=@Stil WHERE id = @Id";
        try
        {
            using var connection = new NpgsqlConnection(url);
            using var command = new NpgsqlCommand(sql, connection);
            command.Parameters.AddWithValue("@IdPersoana", participant.getIdPersoana());
            command.Parameters.AddWithValue("@Distanta", participant.getDistanta().ToString());
            command.Parameters.AddWithValue("@Stil", participant.getStil().ToString());
            command.Parameters.AddWithValue("@Id", participant.Id);
    
            connection.Open();
            command.ExecuteNonQuery();
            log.Info("update was succesfully executed.");
            return true;
        }
        catch (NpgsqlException e)
        {
            log.Error("There was a problem with update.");
            return false;
        }
    }
    
    
    
    public Dictionary<long, Participant> findAllByCompetition(string st,string dist)
    {
        log.Info("Executing findAllByCompetition");
        Dictionary<long,Participant> probe = new Dictionary<long, Participant>();
        string sql = "select * from participanti where idpersoana in (select idpersoana from participanti where distanta=@dist and stil=@st)";
        try
        {
            using var connection = new NpgsqlConnection(url);
            using var command = new NpgsqlCommand(sql, connection);
            {
                connection.Open();
                command.Parameters.AddWithValue("@dist", dist);
                command.Parameters.AddWithValue("@st", st);
                NpgsqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    long id = reader.GetInt64(reader.GetOrdinal("id"));
                    long idPersoana = reader.GetInt64(reader.GetOrdinal("idpersoana"));
                    string distanta = reader.GetString(reader.GetOrdinal("distanta"));
                    string stil = reader.GetString(reader.GetOrdinal("stil"));

                    Participant p = new Participant(idPersoana, (Distanta)Enum.Parse(typeof(Distanta),distanta), (Stil)Enum.Parse(typeof(Stil),stil));
                    p.Id = id;
                    probe.Add(id, p);
                }
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.ToString());
            log.Error("There was a problem with findAllByCompetition.");
            return null;
        }
        log.Info("findByParticipant was successfully executed");
        return probe;
    }
    
    
    
    public int getNumarParticipantiDupaProba(string stil, string dist)
    {
        string sql = "select count(*) from participanti where stil=@Stil and distanta=@Dist";
        try
        {
            using var connection = new NpgsqlConnection(url);
            using var command = new NpgsqlCommand(sql, connection);
            {
                connection.Open();
                command.Parameters.AddWithValue("@Stil", stil);
                command.Parameters.AddWithValue("@Dist", dist);
                NpgsqlDataReader reader=command.ExecuteReader();
                if (reader.Read())
                    return reader.GetInt32(0); 
            }
        }
        catch (Exception e)
        {
            log.Error("There was a problem with getNumarParticipantiDupaProba");
        }
        return -1;
    }


    public Participant findParticipantByIdAndCompetition(long idParticipant,string st,string dist)
    {
        log.Info("Executing findOne");
        string sql = "SELECT * from participanti where idpersoana=@id and stil=@Stil and distanta=@Distanta";
        try
        {
            using var connection = new NpgsqlConnection(url);
            using var command = new NpgsqlCommand(sql,connection);
            {
                connection.Open();
                command.Parameters.AddWithValue("@id", idParticipant);
                command.Parameters.AddWithValue("@Stil", st);
                command.Parameters.AddWithValue("@Distanta", dist);
                NpgsqlDataReader reader=command.ExecuteReader();
                if (reader.Read())
                {
                    long idPersoana = reader.GetInt64(reader.GetOrdinal("idpersoana"));
                    // Participant p = new Participant(nume, varsta);
                    Participant p = new Participant(idPersoana, (Distanta)Enum.Parse(typeof(Distanta),dist), (Stil)Enum.Parse(typeof(Stil),st));
                    p.Id = idParticipant;
                    log.Info("Execution ended succesfully");
                    return p;
                }
                return null;
            }
        }
        catch (NpgsqlException e)
        {
            log.Error("There was a problem with findOne.");
            return null;
        }
    }
    
    

    public long getNewId()
    {
        string sql = "select max(id) from participanti";
        try
        {
            using var connection = new NpgsqlConnection(url);
            using var command = new NpgsqlCommand(sql, connection);
            connection.Open();
            NpgsqlDataReader reader=command.ExecuteReader();
            if (reader.Read())
                return reader.GetInt32(0)+1;
        }
        catch (Exception e)
        {
            log.Error("There was a problem with getNewId");
        }
        return -1;
    }
}