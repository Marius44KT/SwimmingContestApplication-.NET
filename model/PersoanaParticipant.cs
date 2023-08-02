
public class PersoanaParticipant:Entity<long>
{
    private Persoana persoana;
    private Participant participant;

    public PersoanaParticipant(Persoana pers, Participant part)
    {
        persoana = pers;
        participant = part;
    }
    

    public Persoana getPersoana()
    {
        return persoana;
    }

    public Participant getParticipant()
    {
        return participant;
    }
}