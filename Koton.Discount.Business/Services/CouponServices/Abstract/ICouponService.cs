using Koton.Discount.Core.Dtos.Concrete;
using Koton.Shared.Response;

namespace Koton.Discount.Business.Services.CouponServices.Abstract
{

    public interface ICouponService
    {
        Task<Response<ResultCouponDto>> GetCouponByIdAsync(int id);
        Task<Response<IEnumerable<ResultCouponDto>>> GetAllCouponsAsync();
        Task<Response<bool>> AddCouponAsync(CreateCouponDto couponDto);
        Task<Response<bool>> UpdateCouponAsync(int id, UpdateCouponDto couponDto);
        Task<Response<bool>> DeleteCouponAsync(int id);
    }
}
