using System;

[Serializable]
public class Angajat:Entity<long>
{
    private string email;
    private string parola;

    public Angajat(string email, string parola)
    {
        this.email = email;
        this.parola = parola;
    }
    

    public string getEmail()
    {
        return email;
    }

    public string getParola()
    {
        return parola;
    }
}