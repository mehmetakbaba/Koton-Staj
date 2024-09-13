using Koton.Core.Dtos.Concrete.ProductDtos;
using Koton.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koton.Core.Dtos.Concrete.ProductImageDtos;
using Koton.Core.Dtos.Concrete.ProdutDetailDtos;

namespace Koton.Business.Services.ProductImageServices.Abstract
{
    public interface IProductImageService
    {
        Task<Response<ResultProductImageDto>> GetProductImageByIdAsync(string id);
        Task<Response<IEnumerable<ResultProductImageDto>>> GetAllProductImagesAsync();
        Task<Response<bool>> AddProductImageAsync(CreateProductImageDto productImageDto);
        Task<Response<bool>> UpdateProductImageAsync(string id, UpdateProductDetailDto productImageDto);
        Task<Response<bool>> DeleteProductImageAsync(string id);
    }
}
