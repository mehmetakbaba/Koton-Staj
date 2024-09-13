using Koton.Core.Dtos.Abstract;

namespace Koton.Core.Dtos.Concrete.ProductDtos;

    public class GetByIdProductDto : IDto
{
        public string Id { get; set; } = default!;
        public string ProductName { get; set; } = default!;
        public decimal ProductPrice { get; set; }
        public List<string> ProductImageUrl { get; set; }
        public decimal ProductAllQuantity { get; set; }
        public Dictionary<string, int> ProductSizeQuantity { get; set; }
        public string ProductColor { get; set; } = default!;
        public string ProductDespriction { get; set; } = default!;
        public string CategoryId { get; set; } = default!;
}

