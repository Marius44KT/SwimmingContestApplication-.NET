using System;
using Newtonsoft.Json;

[Serializable]
public class Participant:Entity<long>
{
    [JsonProperty("idPersoana")]
    private long idPersoana;
    [JsonProperty("distanta")]
    private Distanta distanta;
    [JsonProperty("stil")]
    private Stil stil;

    public Participant(){}
    
    public Participant(long idParticip,Distanta dist, Stil stilul)
    {
        idPersoana = idParticip;
        distanta = dist;
        stil = stilul;
    }

    public long getIdPersoana()
    {
        return idPersoana;
    }

    public Distanta getDistanta()
    {
        return distanta;
    }

    public Stil getStil()
    {
        return stil;
    }

    
    public void setDistanta(Distanta dist)
    {
        this.distanta = dist;
    }

    public void setIdPersoana(long idPers)
    {
        this.idPersoana = idPers;
    }

    public void setStil(Stil newStil)
    {
        this.stil = newStil;
    }
}