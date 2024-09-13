using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Koton.Business.Services.ProductImageServices.Abstract;
using Koton.Core;
using Koton.Core.Dtos.Concrete.ProductImageDtos;
using Koton.Core.Dtos.Concrete.ProdutDetailDtos;
using Koton.DataAccess.Repositories.MongoDb.ProductImageRepository.Abstract;
using Koton.DataAccess.Repositories.MongoDb.ProductRepository.Concrete;
using Koton.Entity.Entities.Concrete;

namespace Koton.Business.Services.ProductImageServices.Concrete
{
    public class ProductImageService(IProductImageRepository productImageRepository, IMapper mapper) : IProductImageService
    {
        public async Task<Response<ResultProductImageDto>> GetProductImageByIdAsync(string id)
        {
            var productImageEntity = await productImageRepository.GetByIdAsync(id);
            if (productImageEntity == null)
            {
                return Response<ResultProductImageDto>.Fail("ProductImage not found", statusCode: 404);
            }

            var productImageDto = mapper.Map<ResultProductImageDto>(productImageEntity);
            return Response<ResultProductImageDto>.Succes(productImageDto, statusCode:200);
        }

        public async Task<Response<IEnumerable<ResultProductImageDto>>> GetAllProductImagesAsync()
        {
            var productImageEntity = await productImageRepository.GetAllAsync();
            var productImageDto = mapper.Map<IEnumerable<ResultProductImageDto>>(productImageEntity);
            return Response<IEnumerable<ResultProductImageDto>>.Succes(productImageDto,200);
        }

        public async Task<Response<bool>> AddProductImageAsync(CreateProductImageDto productImageDto)
        {
            try
            {
                var productImageEntity = mapper.Map<ProductImage>(productImageDto);
                await productImageRepository.AddAsync(productImageEntity);
                return Response<bool>.Succes(true, 201);
            }
            catch (Exception ex)
            {
                return Response<bool>.Fail($"An error occured: {ex.Message}", 500);
            }
        }

        public async Task<Response<bool>> UpdateProductImageAsync(string id, UpdateProductDetailDto productImageDto)
        {
            var existingProductImage = await productImageRepository.GetByIdAsync(id);

            if (existingProductImage == null)
            {
                return Response<bool>.Fail("ProductImage not found", 404);
            }

            try
            {
                var productImageEntity = mapper.Map<ProductImage>(productImageDto);
                return Response<bool>.Succes(true, 200);
            }
            catch (Exception ex)
            {
                return Response<bool>.Fail($"An error occurred: {ex.Message}", 500);
            }
        }

        public async Task<Response<bool>> DeleteProductImageAsync(string id)
        {
            var existingProductImage = await productImageRepository.GetByIdAsync(id);

            if (existingProductImage == null)
            {
                return Response<bool>.Fail("ProductImage not found", 404);
            }

            try
            {
                await productImageRepository.DeleteAsync(id);
                return Response<bool>.Succes(true,200);
            }
            catch (Exception ex)
            {
                return Response<bool>.Fail($"An error Occured {ex.Message}", 500);
            }
        }
    }
}
