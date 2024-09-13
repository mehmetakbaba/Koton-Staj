using Koton.Business.Services.CategoryServices.Abstract;
using Koton.Core.Dtos.Concrete.CategoryDtos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Koton.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryByIdAsync(string id)
        {
            var response = await _categoryService.GetCategoryByIdAsync(id);

            if (!response.IsSuccesful)
            {
                return StatusCode(response.StatusCode, response);
            }

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategoriesAsync()
        {
            var response = await _categoryService.GetAllCategoriesAsync();
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddCategoryAsync([FromBody] CreateCategoryDto categoryDto)
        {
            var response = await _categoryService.AddCategoryAsync(categoryDto);

            if (!response.IsSuccesful)
            {
                return StatusCode(response.StatusCode, response);
            }

            return StatusCode(response.StatusCode, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategoryAsync(string id, [FromBody] UpdateCategoryDto categoryDto)
        {
            var response = await _categoryService.UpdateCategoryAsync(id, categoryDto);

            if (!response.IsSuccesful)
            {
                return StatusCode(response.StatusCode, response);
            }

            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoryAsync(string id)
        {
            var response = await _categoryService.DeleteCategoryAsync(id);

            if (!response.IsSuccesful)
            {
                return StatusCode(response.StatusCode, response);
            }

            return StatusCode(response.StatusCode, response);
        }
    }
}
