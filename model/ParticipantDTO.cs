using System;

[Serializable]
public class ParticipantDTO
{
    private string nume;
    private int varsta;
    private string stil;
    private string distanta;

    public ParticipantDTO(string name, int age, string style, string distance)
    {
        nume = name;
        varsta = age;
        stil = style;
        distanta = distance;
    }

    
    public string getNume()
    {
        return nume;
    }

    
    public int getVarsta()
    {
        return varsta;
    }

    
    public string getStil()
    {
        return stil;
    }

    
    public string getDistanta()
    {
        return distanta;
    }
}