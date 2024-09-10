using Catalogue.Infrastructure.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Catalogue.Infrastructure.Data;

public class CatalogueDbContext(DbContextOptions<CatalogueDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
}