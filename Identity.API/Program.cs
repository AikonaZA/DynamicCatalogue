using API.Core;
using DynamicCatalogue.ServiceDefaults;
using Identity.Data;
using Identity.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = AppHost.CreateBuilder(args, (services, configuration) =>
{
    // Add services specific to Identity.API
    services.AddDbContext<IdentityDbContext>(options =>
        options.UseSqlServer(configuration.GetConnectionString("IdentityDb")));

    services.AddIdentity<ApplicationUser, IdentityRole>()
        .AddEntityFrameworkStores<IdentityDbContext>()
        .AddDefaultTokenProviders();

    // Add any additional specific services or configurations
});

// Add service defaults & Aspire components.
builder.AddServiceDefaults();

var app = builder.Build();

AppHost.ConfigurePipeline(app);

app.MapDefaultEndpoints();

app.Run();