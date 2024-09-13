using Koton.Core.Dtos.Abstract;

namespace Koton.Core.Dtos.Concrete.ProductImageDtos;

    public class CreateProductImageDto : IDto
{
        public List<string> ProductImageUrl { get; set; }
        public string ProductId { get; set; }
}

