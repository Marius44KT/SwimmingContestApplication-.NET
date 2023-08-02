using concursInot;

public interface PersoaneIRepository<ID,T>:GenericRepository<ID,T> where T:Entity<ID>
{
    Persoana findOneByNumeAndVarsta(string nume, int varsta);

    public long getNewId();
}