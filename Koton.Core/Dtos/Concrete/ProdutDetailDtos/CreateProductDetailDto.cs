using Koton.Core.Dtos.Abstract;

namespace Koton.Core.Dtos.Concrete.ProdutDetailDtos;

    public class CreateProductDetailDto : IDto
{
        
        public string ProductDetailDescription { get; set; } = default!;
        public string ProductId { get; set; }
}

