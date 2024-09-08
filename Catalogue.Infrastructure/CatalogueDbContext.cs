using Catalogue.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Catalogue.Infrastructure
{
    public class CatalogueDbContext : DbContext
    {
        public CatalogueDbContext(DbContextOptions<CatalogueDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
