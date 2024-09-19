using Koton.Basket.Api.Dtos;

namespace Koton.Basket.Api.Services.Abstract
{
    public interface IBasketService
    {
        Task<BasketDto> GetBasket(string userId);
        Task SaveBasket(BasketDto basket);
        Task DeleteBasket(string userId);

    }
}
