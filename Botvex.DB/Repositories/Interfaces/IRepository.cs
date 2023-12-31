﻿using System.Linq.Expressions;

namespace Botvex.DB.Repositories.Interfaces;

public interface IRepository<T>
{
    T Add(T entity);
    List<T> AddRange(List<T> entities);
    IQueryable<T> GetAll();
    IQueryable<T> GetAllNoTracking();
    T? GetSingle(Expression<Func<T, bool>> predicate);
    T? GetSingleNoTracking(Expression<Func<T, bool>> predicate);
    IQueryable<T> GetByCondition(Expression<Func<T, bool>> predicate);
    T? GetSingle(params object?[]? keyValues);
    IQueryable<T> GetMany(Expression<Func<T, bool>> predicate);
    public T Update(T entity, T oldEntity);
    T Remove(T entity);
    int SaveChanges();
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}