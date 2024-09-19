using AutoMapper;
using Koton.Catalog.Business.Services.CategoryServices.Abstract;
using Koton.Catalog.DataAccess.Repositories.MongoDb.CategoryRepository.Abstract;
using Koton.Catalog.Entity.Entities.Concrete;
using Koton.Core.Dtos.Concrete.CategoryDtos;
using Koton.Shared.Response;

namespace Koton.Catalog.Business.Services.CategoryServices.Concrete
{
    public class CategoryService(ICategoryRepository categoryRepository, IMapper mapper) : ICategoryService
    {

        public async Task<Response<ResultCategoryDto>> GetCategoryByIdAsync(string id)
        {
            var categoryEntity = await categoryRepository.GetByIdAsync(id);

            if (categoryEntity == null)
            {
                return Response<ResultCategoryDto>.Fail("Category not found", 404);
            }

            var categoryDto = mapper.Map<ResultCategoryDto>(categoryEntity);
            return Response<ResultCategoryDto>.Succes(categoryDto, 200);
        }

        public async Task<Response<IEnumerable<ResultCategoryDto>>> GetAllCategoriesAsync()
        {
            var categoryEntities = await categoryRepository.GetAllAsync();
            var categoryDtos = mapper.Map<IEnumerable<ResultCategoryDto>>(categoryEntities);

            return Response<IEnumerable<ResultCategoryDto>>.Succes(categoryDtos, 200);
        }

        public async Task<Response<bool>> AddCategoryAsync(CreateCategoryDto categoryDto)
        {
            try
            {
                var categoryEntity = mapper.Map<Category>(categoryDto);
                await categoryRepository.AddAsync(categoryEntity);
                return Response<bool>.Succes(true, 201);
            }
            catch (Exception ex)
            {

                return Response<bool>.Fail($"An error occurred: {ex.Message}", 500);
            }
        }

        public async Task<Response<bool>> UpdateCategoryAsync(string id, UpdateCategoryDto categoryDto)
        {
            var existingCategory = await categoryRepository.GetByIdAsync(id);

            if (existingCategory == null)
            {
                return Response<bool>.Fail("Category not found", 404);
            }

            try
            {
                var categoryEntity = mapper.Map<Category>(categoryDto);


                await categoryRepository.UpdateAsync(id, categoryEntity);
                return Response<bool>.Succes(true, 200);
            }
            catch (Exception ex)
            {
                return Response<bool>.Fail($"An error occurred: {ex.Message}", 500);
            }
        }

        public async Task<Response<bool>> DeleteCategoryAsync(string id)
        {
            var existingCategory = await categoryRepository.GetByIdAsync(id);

            if (existingCategory == null)
            {
                return Response<bool>.Fail("Category not found", 404);
            }

            try
            {
                await categoryRepository.DeleteAsync(id);
                return Response<bool>.Succes(true, 200);
            }
            catch (Exception ex)
            {
                return Response<bool>.Fail($"An error occurred: {ex.Message}", 500);
            }
        }
    }
}