using System;
using Core.Entities;
using Core.Interfaces;

namespace Infrastructure.Interfaces;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<T?>GetByIdAsync(int id);
    Task<IReadOnlyList<T?>> ListAllAsync();
    Task<T?> GetEntityWithSpecAsync(ISpecification<T> spec);
    Task<IReadOnlyList<T>> ListWithSpecAsync(ISpecification<T> spec);
    void Add(T entity);
    void Update(T entity);
    void Remove(T entity);
    Task<bool> SaveChangesAsync();
    Task<bool> ExistsAsync(int id);
}