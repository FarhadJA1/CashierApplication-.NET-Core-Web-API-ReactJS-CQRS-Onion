namespace B.Repository.Repositories.Interfaces;
public interface IRepository<T>
{
    Task<List<T>> GetAllAsync();
    Task<T> GetAsync(int id);
    Task CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}
