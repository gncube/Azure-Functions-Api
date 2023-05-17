using GSN.Application.Interfaces;
using GSN.Infrastructure.Data;

namespace GSN.Infrastructure.Repositories;
public class Repository<T, TKey> : IRepository<T, TKey> where T : class
{
    private readonly AppDbContext _context;

    public Repository(AppDbContext context)
    {
        _context = context;
        _context.Database.EnsureCreated();
    }
    public IEnumerable<T> GetAll()
    {
        return _context.Set<T>().ToList();
    }

    public T GetById(TKey id)
    {
        T? result = _context.Set<T>().Find(id);
        if (result == null)
        {
            throw new ArgumentException($"Item with id {id} not found in database.");
        }
        return result;
    }

    public T Add(T t)
    {
        _context.Set<T>().Add(t);
        _context.SaveChanges();
        return t;
    }

    public T Update(T t)
    {
        _context.Set<T>().Update(t);
        _context.SaveChanges();
        return t;
    }

    public bool Delete(TKey id)
    {
        T? result = _context.Set<T>().Find(id);
        if (result == null)
        {
            return false;
        }
        _context.Set<T>().Remove(result);
        return _context.SaveChanges() > 0;
    }
}
