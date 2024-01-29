using Botvex.DB.Contexts;
using Botvex.DB.Contexts.Interfaces;
using Botvex.DB.Repositories.Beatmap;
using Botvex.DB.Repositories.Beatmap.Interfaces;
using Botvex.DB.Repositories.Beatmapset;
using Botvex.DB.Repositories.Beatmapset.Interfaces;
using Botvex.DB.Repositories.User;
using Botvex.DB.Repositories.User.Interfaces;
using Botvex.osu.Services;
using Botvex.osu.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Botvex.osu;

public class Program
{
    public static void Main()
    {
        var builder = WebApplication.CreateBuilder();

        var services = builder.Services;
        var configuration = builder.Configuration;
        
        configuration.AddJsonFile("appsettings.json", true, true);
        
        services.AddDbContextPool<IBotvexContext, BotvexContext>(options =>
        {
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultBotvexDbConnection") ??
                throw new NullReferenceException("Could not find Botvex connection string"),
                sqlServerOptions => sqlServerOptions.CommandTimeout(90));
        });
        AddAppServices(services);
        
        // Add services to the container.
        services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        // if (app.Environment.IsDevelopment())
        // {
            app.UseSwagger();
            app.UseSwaggerUI();
        // }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
    
    private static void AddAppServices(IServiceCollection services)
    {
        //Add db repositories
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IBeatmapRepository, BeatmapRepository>();
        services.AddScoped<IBeatmapsetRepository, BeatmapsetRepository>();
        services.AddScoped<IGenreRepository, GenreRepository>();
        services.AddScoped<ILanguageRepository, LanguageRepository>();
        
        services.AddScoped<IOsuApiService, OsuApiService>();
        services.AddHttpClient<IOsuApiService, OsuApiService>();
    }
}



