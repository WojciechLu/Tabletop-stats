using TabletopStats.Domain.Entities;

namespace TabletopStats.Application.Interface.Persistence;

public interface IGenericRepository<T> where T : class
{
    /* Commands */
    Task InsertAsync(T entity);
    Task UpdateAsync(T entity);
    Task<bool> DeleteAsync(Guid id);
    /* Queries */
    Task<T?> GetAsync(Guid id);
    Task<IEnumerable<T>> GetAllAsync();
}