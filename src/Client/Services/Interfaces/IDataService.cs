namespace Client.Services.Interfaces;

public interface IDataService<T, TKey>
{
    Task<IEnumerable<T>> GetAllAsync(bool refreshRequired = false);
    Task<IEnumerable<T>> GetAsync();
    Task<T> GetByIdAsync(TKey id);
    Task<T> CreateAsync(T t);
    Task UpdateAsync(T t);
    Task DeleteAsync(TKey id);
}

