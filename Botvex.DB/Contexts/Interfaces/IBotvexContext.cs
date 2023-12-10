using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Botvex.DB.Contexts.Interfaces;

public interface IBotvexContext
{
    public DbSet<T> Set<T>() where T : class;
    public EntityEntry<T> Add<T>(T entity) where T : class;
    public EntityEntry<T> Update<T>(T entity) where T : class;
    public EntityEntry<T> Remove<T>(T entity) where T : class;
    public int SaveChanges();
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    public void AddRange(IEnumerable<object> entities);
}