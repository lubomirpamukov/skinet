using System;
using Core.Entities;

namespace Infrastructure.Interfaces;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<T?>GetByIdAsync(int id);
    Task<IReadOnlyList<T?>> ListAllAsync();
    void Add(T entity);
    void Update(T entity);
    void Remove(T entity);
    Task<bool> SaveAllAsync();
    bool Exists(int id);
}
