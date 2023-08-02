using System;

[Serializable]
public class Persoana:Entity<long>
{
    private string nume;
    private int varsta;

    public Persoana(string name, int age)
    {
        nume = name;
        varsta = age;
    }

    public string getNume()
    {
        return nume;
    }

    public int getVarsta()
    {
        return varsta;
    }
}