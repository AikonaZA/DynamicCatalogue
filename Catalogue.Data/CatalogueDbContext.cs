using Catalogue.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Catalogue.Data
{
    public class CatalogueDbContext : DbContext
    {
        public CatalogueDbContext(DbContextOptions<CatalogueDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
