using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace API.Core;

public static class AppHost
{
    public static WebApplicationBuilder CreateBuilder(string[] args, Action<IServiceCollection, IConfiguration> configureServices = null)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Load configuration sources if needed
        ConfigureConfiguration(builder.Configuration);

        // Register default services
        ConfigureDefaultServices(builder.Services, builder.Configuration);

        // Allow additional service configurations to be injected from specific APIs
        configureServices?.Invoke(builder.Services, builder.Configuration);

        return builder;
    }

    public static void ConfigureConfiguration(IConfigurationBuilder config)
    {
        // Add additional configuration sources here if needed
        config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
              .AddEnvironmentVariables();
    }

    public static void ConfigureDefaultServices(IServiceCollection services, IConfiguration configuration)
    {
        // Register common services used by all APIs
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }

    public static void ConfigurePipeline(WebApplication app)
    {
        // Configure the common middleware used across all APIs
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();
    }
}