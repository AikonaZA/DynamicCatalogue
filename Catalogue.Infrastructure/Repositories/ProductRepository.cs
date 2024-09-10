using Catalogue.Infrastructure.Data;
using Catalogue.Infrastructure.Domain.Entities;
using Catalogue.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Catalogue.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly CatalogueDbContext _context;

        public ProductRepository(CatalogueDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.Include(p => p.Category).ToListAsync();
        }

        public async Task AddAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }
    }
}
