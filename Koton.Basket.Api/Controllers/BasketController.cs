using Koton.Basket.Api.Dtos;
using Koton.Basket.Api.LoginServices.Abstract;
using Koton.Basket.Api.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Koton.Basket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController(IBasketService basketService, ILoginService loginService) : ControllerBase
    {
        private readonly IBasketService _basketService = basketService;
        private readonly ILoginService _loginService = loginService;

        [HttpGet]
        public async Task<IActionResult> GetBasketAllItem()
        {
            var values = await _basketService.GetBasket(_loginService.GetUserId);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> SaveMyBasket(BasketDto basketDto)
        {
            basketDto.UserId = _loginService.GetUserId;
            await _basketService.SaveBasket(basketDto);
            return Ok("Succes basket save");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBasketAllItem()
        {
            await _basketService.DeleteBasket(_loginService.GetUserId);
            return Ok("Succes basket delete");
        }


    }
}
