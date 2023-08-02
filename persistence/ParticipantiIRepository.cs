using System.Collections.Generic;
using concursInot;

public interface ParticipantiIRepository<ID,T>:GenericRepository<ID,T> where T:Entity<ID>
{
    Dictionary<ID, T> findAllByCompetition(string distanta, string stil);

    int getNumarParticipantiDupaProba(string stil, string distanta);

    Participant findParticipantByIdAndCompetition(long id,string stil,string distanta);
    
    public long getNewId();
}