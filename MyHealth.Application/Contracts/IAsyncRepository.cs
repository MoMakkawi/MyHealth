namespace MyHealth.Application.Contracts;

public interface IAsyncRepository<T> where T : class
{
    Task<dynamic> AddAsync(T entity);
    Task<T> GetByIdAsync(dynamic id);
    Task UpdateAsync(T entity);
    Task DeleteAsync(Guid id);

}
