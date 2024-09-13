using Koton.Core.Dtos.Concrete.ProductDtos;
using Koton.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koton.Core.Dtos.Concrete.ProdutDetailDtos;

namespace Koton.Business.Services.ProductDetailServices.Abstract
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
