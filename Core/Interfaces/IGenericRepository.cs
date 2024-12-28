using Core.Entities;
using Core.Interfaces;

namespace Infrastructure.Interfaces;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<T?>GetByIdAsync(int id);
    Task<IReadOnlyList<T?>> ListAllAsync();
    Task<T?> GetEntityWithSpecAsync(ISpecification<T> spec);
    Task<IReadOnlyList<T>> ListWithSpecAsync(ISpecification<T> spec);
    Task<TResult?> GetEntityWithSpecAsync<TResult>(ISpecification<T, TResult> spec);
    Task<IReadOnlyList<TResult>> ListWithSpecAsync<TResult>(ISpecification<T, TResult> spec);
    void Add(T entity);
    void Update(T entity);
    void Remove(T entity);
    Task<bool> SaveChangesAsync();
    Task<bool> ExistsAsync(int id);
    Task<int> CountAsync(ISpecification<T> spec);
}
