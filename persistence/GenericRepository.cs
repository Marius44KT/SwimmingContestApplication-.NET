using System.Collections.Generic;
// using concursInot.Entities;
using concursInot;

public interface GenericRepository<ID, E> where E : Entity<ID>
{
    E findOne(ID id);

    Dictionary<ID, E> findAll();

    bool save(E entity);
    
    bool delete(ID id);
    
    bool update(E entity);
}