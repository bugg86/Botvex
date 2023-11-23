using Microsoft.EntityFrameworkCore;

namespace Botvex.DB.Contexts.Interfaces;

public interface IBotvexContext
{
    public DbSet<T> Set<T>() where T : class;
    
}