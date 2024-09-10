using Catalogue.Infrastructure.Data;
using Catalogue.Infrastructure.Interfaces;
using Catalogue.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catalogue.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCatalogueInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("CatalogueDb");

            // Register DbContext with SQLite connection string
            services.AddDbContext<CatalogueDbContext>(options =>
                options.UseSqlServer(connectionString));

            // Register the repository
            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
