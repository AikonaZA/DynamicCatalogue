using API.Core;

var builder = AppHost.CreateBuilder(args, (services, configuration) =>
{
    // Add services specific to Basket.API
    services.AddStackExchangeRedisCache(options =>
    {
        options.Configuration = configuration.GetConnectionString("RedisConnection");
    });

    // Add any additional specific services or configurations
});

// Add service defaults & Aspire components.
builder.AddServiceDefaults();

var app = builder.Build();

AppHost.ConfigurePipeline(app);

app.Run();
