using Koton.Core;
using Koton.Core.Dtos.Concrete.ProductDtos;

namespace Koton.Business.Services.ProductServices.Abstract
{
    public interface IProductService
    {
        Task<Response<ResultProductDto>> GetProductByIdAsync(string id);
        Task<Response<IEnumerable<ResultProductDto>>> GetAllProductsAsync();
        Task<Response<bool>> AddProductAsync(CreateProductDto productDto);
        Task<Response<bool>> UpdateProductAsync(string id, UpdateProductDto productDto);
        Task<Response<bool>> DeleteProductAsync(string id);
    }
}
