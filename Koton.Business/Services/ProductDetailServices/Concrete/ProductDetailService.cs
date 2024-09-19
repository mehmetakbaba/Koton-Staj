using AutoMapper;
using Koton.Catalog.Business.Services.ProductDetailServices.Abstract;
using Koton.Catalog.DataAccess.Repositories.MongoDb.ProductDetailRepository.Abstract;
using Koton.Catalog.Entity.Entities.Concrete;
using Koton.Core.Dtos.Concrete.ProdutDetailDtos;

using Koton.Shared.Response;

namespace Koton.Catalog.Business.Services.ProductDetailServices.Concrete
{
    public class ProductDetailService(IProductDetailRepository productDetailRepository, IMapper mapper) : IProductDetailDetailService
    {
        public async Task<Response<ResultProductDetailDto>> GetProductDetailByIdAsync(string id)
        {
            var productDetailEntity = await productDetailRepository.GetByIdAsync(id);

            if (productDetailEntity == null)
            {
                return Response<ResultProductDetailDto>.Fail("ProductDetail not found", 404);
            }

            var productDetailDto = mapper.Map<ResultProductDetailDto>(productDetailEntity);
            return Response<ResultProductDetailDto>.Succes(productDetailDto, 200);
        }

        public async Task<Response<IEnumerable<ResultProductDetailDto>>> GetAllProductDetailsAsync()
        {
            var productDetailEntity = await productDetailRepository.GetAllAsync();
            var productDetailDtos = mapper.Map<IEnumerable<ResultProductDetailDto>>(productDetailEntity);

            return Response<IEnumerable<ResultProductDetailDto>>.Succes(productDetailDtos, 200);
        }

        public async Task<Response<bool>> AddProductDetailAsync(CreateProductDetailDto productDetailDto)
        {

            try
            {
                var productDetailEntity = mapper.Map<ProductDetail>(productDetailDto);
                await productDetailRepository.AddAsync(productDetailEntity);
                return Response<bool>.Succes(true, 201);
            }
            catch (Exception ex)
            {

                return Response<bool>.Fail($"An error occurred: {ex.Message}", 500);
            }
        }

        public async Task<Response<bool>> UpdateProductDetailAsync(string id, UpdateProductDetailDto productDetailDto)
        {

            var existingProductDetail = await productDetailRepository.GetByIdAsync(id);

            if (existingProductDetail == null)
            {
                return Response<bool>.Fail("ProductDetail not found", 404);
            }

            try
            {
                var productDetailEntity = mapper.Map<ProductDetail>(productDetailDto);


                await productDetailRepository.UpdateAsync(id, productDetailEntity);
                return Response<bool>.Succes(true, 200);
            }
            catch (Exception ex)
            {
                return Response<bool>.Fail($"An error occurred: {ex.Message}", 500);
            }
        }

        public async Task<Response<bool>> DeleteProductDetailAsync(string id)
        {
            var existingProductDetail = await productDetailRepository.GetByIdAsync(id);

            if (existingProductDetail == null)
            {
                return Response<bool>.Fail("ProductDetail not found", 404);
            }

            try
            {
                await productDetailRepository.DeleteAsync(id);
                return Response<bool>.Succes(true, 200);
            }
            catch (Exception ex)
            {
                return Response<bool>.Fail($"An error occurred: {ex.Message}", 500);
            }
        }
    }
}
