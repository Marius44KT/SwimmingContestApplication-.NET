using System.Collections.Generic;
namespace concursInot;


public class InMemoryRepository<ID, E> : GenericRepository<ID, E> where E : Entity<ID>
{
    private Dictionary<ID, E> entities;

    
    public InMemoryRepository()
    {
        entities = new Dictionary<ID, E>();
    }

    
    public E findOne(ID id)
    {
        if (id == null || !entities.ContainsKey(id))
            return null;

        return entities[id];
    }

    
    public Dictionary<ID, E> findAll()
    {
        return entities;
    }

    
    public bool save(E entity)
    {
        if (entity == null)
            return false;

        entities[entity.Id] = entity;
        return true;
    }

    
    public bool delete(ID id)
    {
        if (!entities.ContainsKey(id))
            return false;

        entities.Remove(id);
        return true;
    }

    
    public bool update(E entity)
    {
        if (entity == null || !entities.ContainsKey(entity.Id))
            return false;

        entities[entity.Id] = entity;
        return true;
    }
}