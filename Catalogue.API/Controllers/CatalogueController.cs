using Catalogue.Application.Interfaces;
using Catalogue.Application.Models;
using Catalogue.Application.Models.Requests;
using DynamicCatalogue.Core.Common;
using DynamicCatalogue.Core.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Catalogue.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CatalogueController : ControllerBase
    {
        private readonly IProductService _productService;

        public CatalogueController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("products")]
        public async Task<IActionResult> GetProducts()
        {
            var result = await _productService.GetAllProductsAsync();

            return result.ResponseCode switch
            {
                HttpResponseCode.Success => Ok(result),
                HttpResponseCode.NoContent => NoContent(),
                _ => StatusCode((int)result.ResponseCode, result)
            };
        }

        [HttpPost("products")]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequest request)
        {
            var result = await _productService.CreateProductAsync(request);

            return result.ResponseCode switch
            {
                HttpResponseCode.Success => CreatedAtAction(nameof(GetProducts), new { id = result.ResponseDetails.Id }, result),
                HttpResponseCode.BadRequest => BadRequest(result),
                HttpResponseCode.InternalServerError => StatusCode(500, result),
                _ => StatusCode((int)result.ResponseCode, result)
            };
        }
    }
}
