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
using Microsoft.ApplicationInsights.DependencyCollector;
using Microsoft.EntityFrameworkCore;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Azure.Core;

namespace Botvex.osu;

public class Program
{
    public static void Main()
    {
        var builder = WebApplication.CreateBuilder();

        var services = builder.Services;
        var configuration = builder.Configuration;
        
        //Configure Azure key vault
        SecretClientOptions options = new SecretClientOptions()
        {
            Retry =
            {
                Delay= TimeSpan.FromSeconds(2),
                MaxDelay = TimeSpan.FromSeconds(16),
                MaxRetries = 5,
                Mode = RetryMode.Exponential
            }
        };
        var client = new SecretClient(new Uri("https://botvex-kv.vault.azure.net/"), new DefaultAzureCredential(),options);

        KeyVaultSecret dbConnString = client.GetSecret("DefaultBotvexDbConnection");
        KeyVaultSecret aiConnString = client.GetSecret("AIConnectionString");
        
        configuration.AddJsonFile("appsettings.json", true, true);
        
        //Configure db
        services.AddDbContextPool<IBotvexContext, BotvexContext>(options =>
        {
            options.UseSqlServer(
                dbConnString.Value ??
                throw new NullReferenceException("Could not find Botvex connection string"),
                sqlServerOptions => sqlServerOptions.CommandTimeout(90));
        });
        AddAppServices(services);
        
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        
        //Configure application insights
        builder.Logging.AddApplicationInsights(
            configureTelemetryConfiguration: (config) =>
            {
                config.ConnectionString = aiConnString.Value;
            },
            configureApplicationInsightsLoggerOptions: (options) => { }
        );
        builder.Services.AddApplicationInsightsTelemetry();
        builder.Services.ConfigureTelemetryModule<DependencyTrackingTelemetryModule>((module, options) =>
        {
            module.EnableSqlCommandTextInstrumentation = true;
        });

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



