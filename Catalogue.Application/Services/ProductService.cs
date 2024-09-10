using AutoMapper;
using Catalogue.Application.Interfaces;
using Catalogue.Application.Models.DTOs;
using Catalogue.Application.Models.Requests;
using Catalogue.Infrastructure.Domain.Entities;
using Catalogue.Infrastructure.Interfaces;
using DynamicCatalogue.Core.Common;

namespace Catalogue.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper; // Inject AutoMapper

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<NewResult<IEnumerable<ProductDto>>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllAsync();
            var productDtos = _mapper.Map<IEnumerable<ProductDto>>(products); // Use AutoMapper to map

            return NewResult<IEnumerable<ProductDto>>.Success(productDtos, "Products retrieved successfully.");
        }

        public async Task<NewResult<ProductDto>> CreateProductAsync(CreateProductRequest request)
        {
            var product = _mapper.Map<Product>(request); // Map CreateProductRequest to Product entity

            try
            {
                await _productRepository.AddAsync(product);

                var productDto = _mapper.Map<ProductDto>(product); // Map Product entity to ProductDto

                return NewResult<ProductDto>.Success(productDto, "Product created successfully.");
            }
            catch (Exception ex)
            {
                return NewResult<ProductDto>.InternalServerError(null, $"Failed to create product: {ex.Message}");
            }
        }
    }
}
