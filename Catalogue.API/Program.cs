using API.Core;
using Catalogue.Application.Interfaces;
using Catalogue.Application.Mappings;
using Catalogue.Application.Services;
using Catalogue.Infrastructure.Extensions;
using DynamicCatalogue.ServiceDefaults;

var builder = AppHost.CreateBuilder(args, (services, configuration) =>
{
    // Add API-specific services here
    services.AddCatalogueInfrastructureLayer(configuration);

    // Add any other specific services related to this API
});

// Register AutoMapper
builder.Services.AddAutoMapper(typeof(CatalogueProfile)); // Register AutoMapper with the profile

// Register Application layer services
builder.Services.AddScoped<IProductService, ProductService>();

// Add service defaults & Aspire components.
builder.AddServiceDefaults();

var app = builder.Build();

AppHost.ConfigurePipeline(app);

app.MapDefaultEndpoints();

app.Run();