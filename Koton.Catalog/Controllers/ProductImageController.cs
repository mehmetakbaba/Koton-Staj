using Koton.Business.Services.ProductImageServices.Abstract;
using Koton.Catalog.Business.Services.ProductServices.Concrete;
using Koton.Catalog.Entity.Entities.Concrete;
using Koton.Core.Dtos.Concrete.ProductDtos;
using Koton.Core.Dtos.Concrete.ProductImageDtos;
using Koton.Core.Dtos.Concrete.ProdutDetailDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Koton.Catalog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImageController(IProductImageService productImageService) : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductByIdAsync(string id)
        {
            var response = await productImageService.GetProductImageByIdAsync(id);
            if (!response.IsSuccesful)
            {
                return StatusCode(response.StatusCode, response);
            }

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllproductImageAsync()
        {
            var response = await productImageService.GetAllProductImagesAsync();
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddProductImageAsync([FromBody] CreateProductImageDto productImageDto)
        {
            var response = await productImageService.AddProductImageAsync(productImageDto);

            if (!response.IsSuccesful)
            {
                return StatusCode(response.StatusCode, response);
            }

            return StatusCode(response.StatusCode, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProductAsync(string id, [FromBody] UpdateProductImageDto prodycImageDto)
        {
            var response = await productImageService.UpdateProductImageAsync(id, prodycImageDto);

            if (!response.IsSuccesful)
            {
                return StatusCode(response.StatusCode, response);
            }
            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductImageAsync(string id)
        {
            var response = await productImageService.DeleteProductImageAsync(id);

            if (!response.IsSuccesful)
            {
                return StatusCode(response.StatusCode, response);
            }

            return StatusCode(response.StatusCode, response);
        }
    }
}
