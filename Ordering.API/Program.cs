using API.Core;
using Microsoft.EntityFrameworkCore;
using Ordering.Data;

var builder = AppHost.CreateBuilder(args, (services, configuration) =>
{
    // Add services specific to Ordering.API
    services.AddDbContext<OrderingDbContext>(options =>
        options.UseSqlServer(configuration.GetConnectionString("OrderingDb")));

    // Add any additional specific services or configurations
});

// Add service defaults & Aspire components.
builder.AddServiceDefaults();

var app = builder.Build();

AppHost.ConfigurePipeline(app);

app.MapDefaultEndpoints();

app.Run();
