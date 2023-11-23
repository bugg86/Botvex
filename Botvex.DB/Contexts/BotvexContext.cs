using Botvex.DB.Contexts.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Botvex.DB.Contexts;

public class BotvexEnvContextFactory :IDesignTimeDbContextFactory<BotvexContext> 
{
    public BotvexContext CreateDbContext(string[] args)
    {
        IConfiguration config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("local.settings.json", optional: true)
            .AddEnvironmentVariables()
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<BotvexContext>();
        optionsBuilder.UseSqlServer(config.GetConnectionString("BOTVEX_CONNECTION"));

        return new BotvexContext(optionsBuilder.Options);
    }
}

public partial class BotvexContext : DbContext, IBotvexContext
{
    public BotvexContext(DbContextOptions<BotvexContext> options) : base(options) { }
}