using concursInot;

public interface AngajatiIRepository<ID,T>:GenericRepository<ID,T> where T:Entity<ID>
{
    Angajat findOneByEmailAndPassword(string email,string pass);
    
    Angajat findOneByEmail(string email);
}