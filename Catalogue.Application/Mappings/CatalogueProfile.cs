using AutoMapper;
using Catalogue.Application.Models.DTOs;
using Catalogue.Application.Models.Requests;
using Catalogue.Domain.Entities;

namespace Catalogue.Application.Mappings
{
    public class CatalogueProfile : Profile
    {
        public CatalogueProfile()
        {
            // Map Product entity to ProductDto
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                .ReverseMap();

            // Map CreateProductRequest to Product entity
            CreateMap<CreateProductRequest, Product>()
                .ReverseMap();
        }
    }
}
