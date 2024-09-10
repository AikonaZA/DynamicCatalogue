using Catalogue.Infrastructure.Data;
using Catalogue.Infrastructure.Domain.Entities;
using Catalogue.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Catalogue.Infrastructure.Repositories;

public class ProductRepository(CatalogueDbContext context) : IProductRepository
{
    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await context.Products.Include(p => p.Category).ToListAsync();
    }

    public async Task AddAsync(Product product)
    {
        context.Products.Add(product);
        await context.SaveChangesAsync();
    }
}