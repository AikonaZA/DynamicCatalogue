using AutoMapper;
using Catalogue.Application.Interfaces;
using Catalogue.Application.Models.DTOs;
using Catalogue.Application.Models.Requests;
using Catalogue.Infrastructure.Domain.Entities;
using Catalogue.Infrastructure.Interfaces;
using DynamicCatalogue.Core.Common;

namespace Catalogue.Application.Services;

public class ProductService(IProductRepository productRepository, IMapper mapper) : IProductService
{
    public async Task<NewResult<IEnumerable<ProductDto>>> GetAllProductsAsync()
    {
        var products = await productRepository.GetAllAsync();
        var productDtos = mapper.Map<IEnumerable<ProductDto>>(products); // Use AutoMapper to map

        return NewResult<IEnumerable<ProductDto>>.Success(productDtos, "Products retrieved successfully.");
    }

    public async Task<NewResult<ProductDto>> CreateProductAsync(CreateProductRequest request)
    {
        var product = mapper.Map<Product>(request); // Map CreateProductRequest to Product entity

        try
        {
            await productRepository.AddAsync(product);

            var productDto = mapper.Map<ProductDto>(product); // Map Product entity to ProductDto

            return NewResult<ProductDto>.Success(productDto, "Product created successfully.");
        }
        catch (Exception ex)
        {
            return NewResult<ProductDto>.InternalServerError(null, $"Failed to create product: {ex.Message}");
        }
    }
}