using Koton.Discount.Business.Services.CouponServices.Abstract;
using Koton.Discount.Business.Services.CouponServices.Concrete;
using Koton.Discount.Core.Dtos.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Koton.Discount.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponController(ICouponService couponService) : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCouponByIdAsync(int id)
        {
            var response = await couponService.GetCouponByIdAsync(id);
            if (!response.IsSuccesful)
            {
                return StatusCode(response.StatusCode, response);
            }

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCouponsAsync()
        {
            var response = await couponService.GetAllCouponsAsync();
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddCouponAsync([FromBody] CreateCouponDto couponDto)
        {
            var response = await couponService.AddCouponAsync(couponDto);
            if (!response.IsSuccesful)
            {
                return StatusCode(response.StatusCode, response);
            }

            return StatusCode(response.StatusCode, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCouponAsync(int id, [FromBody] UpdateCouponDto couponDto)
        {
            var response = await couponService.UpdateCouponAsync(id, couponDto);

            if (!response.IsSuccesful)
            {
                return StatusCode(response.StatusCode, response);
            }
            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCouponAsync(int id)
        {
            var response = await couponService.DeleteCouponAsync(id);

            if (!response.IsSuccesful)
            {
                return StatusCode(response.StatusCode, response);
            }

            return StatusCode(response.StatusCode, response);
            ;
        }
    }
}
