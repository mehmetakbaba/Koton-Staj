using System.ComponentModel.DataAnnotations;

namespace Koton.Basket.Api.Dtos
{
    public class BasketDto
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "The basket must contain at least one product.")]
        public List<BasketItemDto> Items { get; set; } = new List<BasketItemDto>();
        public string DiscountCode { get; set; }
        public decimal TotalPrice { get => Items.Sum(x => x.Price * x.Quantity); }
    }
}
