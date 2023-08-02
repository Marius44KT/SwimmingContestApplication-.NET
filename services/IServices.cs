using System.Collections.Generic;

namespace services;

public interface IServices
{
    bool login(string date, string password, IObserver client);

    List<ParticipantDTO> getParticipanti();
    
    List<ParticipantDTO> getSearchedParticipanti(string stil,string distanta);

    List<int> getNumarParticipantiDupaProba();

    void inscriereParticipant(string nume, int varsta, string stil, string distanta);
    
    void logout(string email);
}