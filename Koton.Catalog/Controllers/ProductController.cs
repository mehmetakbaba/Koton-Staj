using Koton.Business.Services.ProductServices.Abstract;
using Koton.Core.Dtos.Concrete.ProductDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Koton.Catalog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IProductService productService) : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductByIdAsync(string id)
        {
            var response = await productService.GetProductByIdAsync(id);
            if (!response.IsSuccesful)
            {
                return StatusCode(response.StatusCode, response);
            }

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductsAsync()
        {
            var response = await productService.GetAllProductsAsync();
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddProductAsync([FromBody] CreateProductDto productDto)
        {
            var response = await productService.AddProductAsync(productDto);

            if (!response.IsSuccesful)
            {
                return StatusCode(response.StatusCode, response);
            }

            return StatusCode(response.StatusCode, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProductAsync(string id, [FromBody] UpdateProductDto productDto)
        {
            var response = await productService.UpdateProductAsync(id, productDto);

            if (!response.IsSuccesful)
            {
                return StatusCode(response.StatusCode, response);
            }
            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductAsync(string id)
        {
            var response = await productService.DeleteProductAsync(id);

            if (!response.IsSuccesful)
            {
                return StatusCode(response.StatusCode, response);
            }

            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("category/{categoryId}")]
        public async Task<IActionResult> GetProductsByCategoryIdAsync(string categoryId)
        {
            var response = await productService.GetProductsByCategoryIdAsync(categoryId);

            if (!response.IsSuccesful)
            {
                return StatusCode(response.StatusCode, response);
            }

            return Ok(response);
        }
    }
}
