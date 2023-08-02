using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using concursInot;
// using concursInot.Entities;
using log4net;
using Npgsql;


public class PersoaneDatabaseRepository : PersoaneIRepository<long, Persoana>
{
    private string url;
    private ILog log;

    public PersoaneDatabaseRepository(string url,ILog logger)
    {
        this.url = url;
        this.log = logger;
        log.Info("Creating PersoaneDatabaseRepository");
    }


    
    public Persoana findOne(long idPersoana)
    {
        log.Info("Executing findOne");
        string sql = "SELECT * from persoane where id=@id";
        try
        {
            using var connection = new NpgsqlConnection(url);
            using var command = new NpgsqlCommand(sql, connection);
            {
                connection.Open();
                command.Parameters.AddWithValue("@id", idPersoana);
                NpgsqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    string nume = reader.GetString(reader.GetOrdinal("nume"));
                    int varsta = reader.GetInt32(reader.GetOrdinal("varsta"));
                    Persoana p = new Persoana(nume, varsta);
                    p.Id = idPersoana;
                    log.Info("Execution ended succesfully");
                    return p;
                }
                return null;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.ToString());
            log.Error("There was a problem with findOne.");
            return null;
        }
    }


    
    public Dictionary<long, Persoana> findAll()
    {
        log.Info("Executing findAll");
        Dictionary<long, Persoana> persoane = new Dictionary<long, Persoana>();
        string sql = "SELECT * from persoane";
        try
        {
            using var connection = new NpgsqlConnection(url);
            using var command = new NpgsqlCommand(sql, connection);
            {
                connection.Open();
                NpgsqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    long persoanaId = reader.GetInt64(reader.GetOrdinal("id"));
                    string nume = reader.GetString(reader.GetOrdinal("nume"));
                    int varsta = reader.GetInt32(reader.GetOrdinal("varsta"));

                    Persoana p = new Persoana(nume, varsta);
                    p.Id = persoanaId;
                    persoane.Add(persoanaId, p);
                }
            }
        }
        catch (NpgsqlException e)
        {
            // Console.WriteLine(e.ToString());
            log.Error("There was a problem with findAll.");
            return null;
        }
        log.Info("findAll was successfully executed");
        return persoane;
    }
    
    
    
    public bool save(Persoana persoana)
    {
        log.Info("Executing save");
        string sql = "INSERT INTO persoane (id, nume, varsta) VALUES (@Id, @Nume, @Varsta)";
        try
        {
            using var connection = new NpgsqlConnection(url);
            using var command = new NpgsqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Id", persoana.Id);
            command.Parameters.AddWithValue("@Nume", persoana.getNume());
            command.Parameters.AddWithValue("@Varsta", persoana.getVarsta());
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
        string sql = "DELETE FROM persoane WHERE id = @Id";
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

    
    
    public bool update(Persoana persoana)
    {
        log.Info("Executing update");
        string sql = "UPDATE persoane SET nume = @Nume, varsta = @Varsta WHERE id = @Id";
        try
        {
            using var connection = new NpgsqlConnection(url);
            using var command = new NpgsqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Nume", persoana.getNume());
            command.Parameters.AddWithValue("@Varsta", persoana.getVarsta());
            command.Parameters.AddWithValue("@Id", persoana.Id);

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
    
    
    
    public Persoana findOneByNumeAndVarsta(string nume,int varsta)
    {
        log.Info("Executing findOneByNumeAndVarsta");
        string sql = "select * from persoane where nume=@Nume and varsta=@Varsta";
        try
        {
            using var connection = new NpgsqlConnection(url);
            using var command = new NpgsqlCommand(sql, connection);
            {
                connection.Open();
                command.Parameters.AddWithValue("@Nume",nume);
                command.Parameters.AddWithValue("@Varsta",varsta);
                NpgsqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    long id=reader.GetInt64(reader.GetOrdinal("id"));
                    Persoana p = new Persoana(nume, varsta);
                    p.Id=id;
                    log.Info("Execution ended succesfully");
                    return p;
                }
                return null;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.ToString());
            log.Error("There was a problem with findOneByNumeAndVarsta.");
            return null;
        }
    }
    
    
    
    public long getNewId()
    {
        string sql = "select max(id) from persoane";
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