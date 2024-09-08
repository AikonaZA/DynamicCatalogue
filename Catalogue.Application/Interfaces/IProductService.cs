using Catalogue.Application.Models;
using Catalogue.Application.Models.DTOs;
using Catalogue.Application.Models.Requests;
using DynamicCatalogue.Core.Common;

namespace Catalogue.Application.Interfaces
{
    public interface IProductService
    {
        Task<NewResult<IEnumerable<ProductDto>>> GetAllProductsAsync();
        Task<NewResult<ProductDto>> CreateProductAsync(CreateProductRequest request);
    }
}
