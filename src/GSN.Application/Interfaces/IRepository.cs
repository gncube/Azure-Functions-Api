namespace GSN.Application.Interfaces;
public interface IRepository<T, TKey> where T : class
{
    IEnumerable<T> GetAll();
    T GetById(TKey id);
    T Add(T t);
    T Update(T t);
    bool Delete(TKey id);
}
