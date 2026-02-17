using System.Linq.Expressions;

namespace HVACManagement.Repositories.Interfaces;

public interface IGenericRepository<T> where T : class
{
    Task<T?> GetByIdAsync(object id);
    Task<IReadOnlyList<T>> ListAsync(Expression<Func<T, bool>>? predicate = null);
    Task AddAsync(T entity);
    void Update(T entity);
    void Delete(T entity);
}
