using Koton.Catalog.Business.Services.ProductDetailServices.Abstract;
using Koton.Core.Dtos.Concrete.ProductDtos;
using Koton.Core.Dtos.Concrete.ProdutDetailDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Koton.Catalog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailController(IProductDetailDetailService productDetail) : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductByIdAsync(string id)
        {
            var response = await productDetail.GetProductDetailByIdAsync(id);
            if (!response.IsSuccesful)
            {
                return StatusCode(response.StatusCode, response);
            }

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllproductDetailsAsync()
        {
            var response = await productDetail.GetAllProductDetailsAsync();
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddProductDetailAsync([FromBody] CreateProductDetailDto productDetailDto)
        {
            var response = await productDetail.AddProductDetailAsync(productDetailDto);

            if (!response.IsSuccesful)
            {
                return StatusCode(response.StatusCode, response);
            }

            return StatusCode(response.StatusCode, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProductDetailAsync(string id, [FromBody] UpdateProductDetailDto productDetailDto)
        {
            var response = await productDetail.UpdateProductDetailAsync(id, productDetailDto);

            if (!response.IsSuccesful)
            {
                return StatusCode(response.StatusCode, response);
            }
            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductDetailAsync(string id)
        {
            var response = await productDetail.DeleteProductDetailAsync(id);

            if (!response.IsSuccesful)
            {
                return StatusCode(response.StatusCode, response);
            }

            return StatusCode(response.StatusCode, response);
        }
    }
}
