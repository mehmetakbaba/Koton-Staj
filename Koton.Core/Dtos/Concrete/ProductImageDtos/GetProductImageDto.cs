using Koton.Core.Dtos.Abstract;

namespace Koton.Core.Dtos.Concrete.ProductImageDtos;

    public class GetProductImageDto : IDto
{
        public string Id { get; set; }
        public List<string> ProductImageUrl { get; set; }
        public string ProductId { get; set; }
}

