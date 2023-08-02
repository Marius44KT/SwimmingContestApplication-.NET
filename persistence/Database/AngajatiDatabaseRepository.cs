using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using log4net;
using Npgsql;
public class AngajatiDatabaseRepository : AngajatiIRepository<long, Angajat>
{
    private string url;
    private ILog log;

    public AngajatiDatabaseRepository(string url,ILog logger)
    {
        this.url = url;
        this.log = logger;
        log.Info("Creating AngajatDatabaseRepository");
    }


    public Angajat findOne(long idAngajat)
    {
        log.Info("Executing findOne");
        string sql = "SELECT * from angajati where id=@id";
        try
        {
            using var connection = new NpgsqlConnection(url);
            using var command = new NpgsqlCommand(sql, connection);
            {
                connection.Open();
                command.Parameters.AddWithValue("@id", idAngajat);
                NpgsqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    string email = reader.GetString(reader.GetOrdinal("email"));
                    string parola = reader.GetString(reader.GetOrdinal("parola"));
                    Angajat a = new Angajat(email,parola);
                    a.Id = idAngajat;
                    log.Info("Execution ended succesfully");
                    return a;
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

    

    public Dictionary<long, Angajat> findAll()
    {
        log.Info("Executing findAll");
        Dictionary<long, Angajat> angajati = new Dictionary<long, Angajat>();
        string sql = "SELECT * from angajati";
        try
        {
            using var connection = new NpgsqlConnection(url);
            using var command = new NpgsqlCommand(sql, connection);
            {
                connection.Open();
                NpgsqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    long angajatId = reader.GetInt64(reader.GetOrdinal("id"));
                    string email = reader.GetString(reader.GetOrdinal("email"));
                    string parola = reader.GetString(reader.GetOrdinal("parola"));

                    Angajat p = new Angajat(email,parola);
                    p.Id = angajatId;
                    angajati.Add(angajatId, p);
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
        return angajati;
    }
    
    
    
    public bool save(Angajat angajat)
    {
        log.Info("Executing save");
        string sql = "INSERT INTO angajati (id, nume, varsta) VALUES (@Id, @Email, @Parola)";
        try
        {
            using var connection = new NpgsqlConnection(url);
            using var command = new NpgsqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Id", angajat.Id);
            command.Parameters.AddWithValue("@Email", angajat.getEmail());
            command.Parameters.AddWithValue("@Parola", angajat.getParola());

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

    
    
    public bool delete(long idAngajat)
    {
        log.Info("Executing delete");
        string sql = "DELETE FROM angajati WHERE id = @Id";
        try
        {
            using var connection = new NpgsqlConnection(url);
            using var command = new NpgsqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Id", idAngajat);

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

    
    
    public bool update(Angajat angajat)
    {
        log.Info("Executing update");
        string sql = "UPDATE angajati SET email=@Email, parola=@Parola WHERE id=@Id";
        try
        {
            using var connection = new NpgsqlConnection(url);
            using var command = new NpgsqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Email", angajat.getEmail());
            command.Parameters.AddWithValue("@Parola", angajat.getParola());
            command.Parameters.AddWithValue("@Id", angajat.Id);

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

    
    
    public Angajat findOneByEmailAndPassword(string email, string pass)
    {
        log.Info("Executing findOneByEmailAndPassword");
        string sql = "select * from angajati where email=@Email and parola=@Parola";
        try
        {
            using var connection = new NpgsqlConnection(url);
            using var command = new NpgsqlCommand(sql, connection);
            {
                connection.Open();
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Parola", pass);
                NpgsqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    long id=reader.GetInt64(reader.GetOrdinal("id"));
                    Angajat a = new Angajat(email,pass);
                    a.Id=id;
                    log.Info("Execution ended succesfully");
                    return a;
                }
                return null;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.ToString());
            log.Error("There was a problem with findOneByEmailAndPassword.");
            return null;
        }
    }
    
    
    
    public Angajat findOneByEmail(string email)
    {
        log.Info("Executing findOneByEmail");
        string sql = "select * from angajati where email=@Email";
        try
        {
            using var connection = new NpgsqlConnection(url);
            using var command = new NpgsqlCommand(sql, connection);
            {
                connection.Open();
                command.Parameters.AddWithValue("@Email", email);
                NpgsqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    long id=reader.GetInt64(reader.GetOrdinal("id"));
                    string parola = reader.GetString(reader.GetOrdinal("parola"));
                    Angajat a = new Angajat(email,parola);
                    a.Id=id;
                    log.Info("Execution ended succesfully");
                    return a;
                }
                return null;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.ToString());
            log.Error("There was a problem with findOneByEmail.");
            return null;
        }
    }
}