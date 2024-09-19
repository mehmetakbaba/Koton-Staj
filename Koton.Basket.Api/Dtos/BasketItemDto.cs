using System.ComponentModel.DataAnnotations;

namespace Koton.Basket.Api.Dtos
{
    public class BasketItemDto
    {
        [Required]
        public string ProductId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "The quantity of the product must be at least 1.")]
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        [Required]
        public string Size { get; set; }
    }
}
