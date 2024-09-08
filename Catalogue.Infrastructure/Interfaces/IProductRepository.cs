using Catalogue.Domain.Entities;

namespace Catalogue.Infrastructure.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task AddAsync(Product product);
    }
}
