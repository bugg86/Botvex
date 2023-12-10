using System.Linq.Expressions;
using Botvex.DB.Contexts.Interfaces;
using Botvex.DB.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Botvex.DB.Repositories;

public abstract class Repository<T> : IRepository<T> where T : class
{
    private readonly IBotvexContext _botvexContext;
    public Repository(IBotvexContext botvexContext)
    {
        _botvexContext = botvexContext;
    }
    public IQueryable<T> GetAll()
    {
        return _botvexContext.Set<T>();
    }
    public IQueryable<T> GetAllNoTracking()
    {
        return _botvexContext.Set<T>().AsNoTracking();
    }
    public T? GetSingle(params object?[]? keyValues)
    {
        return _botvexContext.Set<T>().Find(keyValues);
    }
    public T? GetSingle(Expression<Func<T, bool>> predicate)
    {
        return _botvexContext.Set<T>().FirstOrDefault(predicate);
    }

    public IQueryable<T> GetByCondition(Expression<Func<T, bool>> predicate)
    {
        return _botvexContext.Set<T>().Where(predicate).AsNoTracking();
    }

    public IQueryable<T> GetMany(Expression<Func<T, bool>> predicate)
    {
        return _botvexContext.Set<T>().Where(predicate);
    }
    public T? GetSingleNoTracking(Expression<Func<T, bool>> predicate)
    {
        return _botvexContext.Set<T>().AsNoTracking().FirstOrDefault(predicate);
    }
    public T Add(T entity)
    {
        _botvexContext.Add(entity);
        return entity;
    }
    public List<T> AddRange(List<T> entities)
    {
        _botvexContext.AddRange(entities);
        return entities;
    }
    public T Update(T entity, T oldEntity)
    {
        oldEntity = entity;
        _botvexContext.Update(oldEntity);
        return oldEntity;
    }
    public T Remove(T entity)
    {
        _botvexContext.Remove(entity);
        return entity;
    }
    public int SaveChanges()
    {
        return _botvexContext.SaveChanges();
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return _botvexContext.SaveChangesAsync(cancellationToken);
    }
}