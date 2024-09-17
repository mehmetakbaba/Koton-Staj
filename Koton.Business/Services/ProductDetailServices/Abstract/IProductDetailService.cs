using Koton.Core.Dtos.Concrete.ProdutDetailDtos;
using Koton.Shared.Response;

namespace Koton.Catalog.Business.Services.ProductDetailServices.Abstract
{
    public interface IProductDetailDetailService
    {
        Task<Response<ResultProductDetailDto>> GetProductDetailByIdAsync(string id);
        Task<Response<IEnumerable<ResultProductDetailDto>>> GetAllProductDetailsAsync();
        Task<Response<bool>> AddProductDetailAsync(CreateProductDetailDto ProductDetailDto);
        Task<Response<bool>> UpdateProductDetailAsync(string id, UpdateProductDetailDto ProductDetailDto);
        Task<Response<bool>> DeleteProductDetailAsync(string id);
    }
}
