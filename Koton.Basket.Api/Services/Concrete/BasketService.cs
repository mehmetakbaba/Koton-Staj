using System.Text.Json;
using Koton.Basket.Api.Dtos;
using Koton.Basket.Api.Services.Abstract;
using Koton.Basket.Api.Settings;

namespace Koton.Basket.Api.Services.Concrete
{
    public class BasketService(RedisService redisService) : IBasketService
    {
        private readonly RedisService _redisService = redisService;

        public async Task<BasketDto> GetBasket(string userId)
        {
           var existBasket = await _redisService.GetDb().StringGetAsync(userId);
           return JsonSerializer.Deserialize<BasketDto>(existBasket);
        }

        public async Task SaveBasket(BasketDto basket)
        {
            await _redisService.GetDb().StringSetAsync(basket.UserId,JsonSerializer.Serialize(basket));
        }

        public async Task DeleteBasket(string userId)
        {
            await _redisService.GetDb().KeyDeleteAsync(userId);
        }
    }
}
