using AutoMapper;
using Koton.DataAccess.Repositories.MongoDb.Abstract;
using Koton.Entity.Entities.Concrete;
using Koton.Core;
using Koton.Core.Dtos.Concrete.CategoryDtos;
using System.Collections.Generic;
using System.Threading.Tasks;
using Koton.Business.Services.CategoryServices.Abstract;
using Koton.DataAccess.Repositories.MongoDb.CategoryRepository;

namespace Koton.Business.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<Response<ResultCategoryDto>> GetCategoryByIdAsync(string id)
        {
            var categoryEntity = await _categoryRepository.GetByIdAsync(id);

            if (categoryEntity == null)
            {
                return Response<ResultCategoryDto>.Fail("Category not found", 404);
            }

            var categoryDto = _mapper.Map<ResultCategoryDto>(categoryEntity);
            return Response<ResultCategoryDto>.Succes(categoryDto, 200);
        }

        public async Task<Response<IEnumerable<ResultCategoryDto>>> GetAllCategoriesAsync()
        {
            var categoryEntities = await _categoryRepository.GetAllAsync();
            var categoryDtos = _mapper.Map<IEnumerable<ResultCategoryDto>>(categoryEntities);

            return Response<IEnumerable<ResultCategoryDto>>.Succes(categoryDtos, 200);
        }

        public async Task<Response<bool>> AddCategoryAsync(CreateCategoryDto categoryDto)
        {
            try
            {
                var categoryEntity = _mapper.Map<Category>(categoryDto);
                await _categoryRepository.AddAsync(categoryEntity);
                return Response<bool>.Succes(true, 201);
            }
            catch (Exception ex)
            {
                
                return Response<bool>.Fail($"An error occurred: {ex.Message}", 500);
            }
        }

        public async Task<Response<bool>> UpdateCategoryAsync(string id, UpdateCategoryDto categoryDto)
        {
            var existingCategory = await _categoryRepository.GetByIdAsync(id);

            if (existingCategory == null)
            {
                return Response<bool>.Fail("Category not found", 404);
            }

            try
            {
                var categoryEntity = _mapper.Map<Category>(categoryDto);
                categoryEntity.Id = id;

                await _categoryRepository.UpdateAsync(id, categoryEntity);
                return Response<bool>.Succes(true, 200);
            }
            catch (Exception ex)
            {
                return Response<bool>.Fail($"An error occurred: {ex.Message}", 500);
            }
        }

        public async Task<Response<bool>> DeleteCategoryAsync(string id)
        {
            var existingCategory = await _categoryRepository.GetByIdAsync(id);

            if (existingCategory == null)
            {
                return Response<bool>.Fail("Category not found", 404);
            }

            try
            {
                await _categoryRepository.DeleteAsync(id);
                return Response<bool>.Succes(true, 200);
            }
            catch (Exception ex)
            {
                return Response<bool>.Fail($"An error occurred: {ex.Message}", 500);
            }
        }
    }
}
