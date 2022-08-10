namespace MyHealth.Application.Contracts;

public interface IAsyncRepository<T> where T : class
{
    Task<T> AddAsync(T entity);
    Task<IEnumerable<T>> GetAllByIdAsync(Guid id);
    Task<T> GetByIdAsync(Guid id);
    Task UpdateAsync(T entity);
    Task DeleteAsync(Guid id);

}
