using API.Core;
using Catalogue.Application.Interfaces;
using Catalogue.Application.Mappings;
using Catalogue.Application.Services;
using Catalogue.Infrastructure;
using Catalogue.Infrastructure.Interfaces;
using Catalogue.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = AppHost.CreateBuilder(args, (services, configuration) =>
{
    // Add API-specific services here
    services.AddDbContext<CatalogueDbContext>(options =>
        options.UseSqlServer(configuration.GetConnectionString("CatalogueDb")));

    // Add any other specific services related to this API
});

// Register AutoMapper
builder.Services.AddAutoMapper(typeof(CatalogueProfile)); // Register AutoMapper with the profile

// Register Application layer services
builder.Services.AddScoped<IProductService, ProductService>();

// Register Infrastructure layer repositories
builder.Services.AddScoped<IProductRepository, ProductRepository>();

// Add service defaults & Aspire components.
builder.AddServiceDefaults();

var app = builder.Build();

AppHost.ConfigurePipeline(app);

app.MapDefaultEndpoints();

app.Run();
