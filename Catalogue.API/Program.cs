using API.Core;
using Catalogue.Data;
using Microsoft.EntityFrameworkCore;

var builder = AppHost.CreateBuilder(args, (services, configuration) =>
{
    // Add API-specific services here
    services.AddDbContext<CatalogueDbContext>(options =>
        options.UseSqlServer(configuration.GetConnectionString("CatalogueDb")));

    // Add any other specific services related to this API
});

// Add service defaults & Aspire components.
builder.AddServiceDefaults();

var app = builder.Build();

AppHost.ConfigurePipeline(app);

app.Run();
