using Koton.Core.Dtos.Concrete.CategoryDtos;
using Koton.Shared.Response;

namespace Koton.Catalog.Business.Services.CategoryServices.Abstract
{
    public interface ICategoryService
    {
        Task<Response<ResultCategoryDto>> GetCategoryByIdAsync(string id);
        Task<Response<IEnumerable<ResultCategoryDto>>> GetAllCategoriesAsync();
        Task<Response<bool>> AddCategoryAsync(CreateCategoryDto categoryDto);
        Task<Response<bool>> UpdateCategoryAsync(string id, UpdateCategoryDto categoryDto);
        Task<Response<bool>> DeleteCategoryAsync(string id);
    }
}