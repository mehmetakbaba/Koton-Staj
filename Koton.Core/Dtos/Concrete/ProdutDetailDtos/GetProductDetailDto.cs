using Koton.Core.Dtos.Abstract;

namespace Koton.Core.Dtos.Concrete.ProdutDetailDtos;

    public class GetProductDetailDto : IDto
{
        public string Id { get; set; } = default!;
        public string ProductDetailDescription { get; set; } = default!;
        public string ProductId { get; set; } = default!;
}

