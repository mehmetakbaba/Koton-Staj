using AutoMapper;
using Koton.Discount.Business.Services.CouponServices.Abstract;
using Koton.Discount.Core.Dtos.Concrete;
using Koton.Discount.DataAccess.Repositories.Dapper.CouponRepository.Abstract;
using Koton.Discount.Entity.Entities.Concrete;
using Koton.Shared.Response;

namespace Koton.Discount.Business.Services.CouponServices.Concrete
{
    public class CouponService(ICouponRepository couponRepository, IMapper mapper) : ICouponService
    {
        public async Task<Response<ResultCouponDto>> GetCouponByIdAsync(int id)
        {
            try
            {
                var couponEntity = await couponRepository.GetByIdAsync(id);

                if (couponEntity == null)
                {
                    return Response<ResultCouponDto>.Fail("CouponController not found", 404);
                }

                var couponDto = mapper.Map<ResultCouponDto>(couponEntity);
                return Response<ResultCouponDto>.Succes(couponDto, 200);
            }
            catch (Exception ex)
            {
                return Response<ResultCouponDto>.Fail($"An error occurred: {ex.Message}", 500);
            }
        }

        public async Task<Response<IEnumerable<ResultCouponDto>>> GetAllCouponsAsync()
        {
            try
            {
                var couponEntities = await couponRepository.GetAllAsync();
                var couponDtos = mapper.Map<IEnumerable<ResultCouponDto>>(couponEntities);

                return Response<IEnumerable<ResultCouponDto>>.Succes(couponDtos, 200);
            }
            catch (Exception ex)
            {
                return Response<IEnumerable<ResultCouponDto>>.Fail($"An error occurred: {ex.Message}", 500);
            }
        }

        public async Task<Response<bool>> AddCouponAsync(CreateCouponDto couponDto)
        {
            try
            {
                var couponEntity = mapper.Map<Coupon>(couponDto);
                await couponRepository.AddAsync(couponEntity);
                return Response<bool>.Succes(true, 201);
            }
            catch (Exception ex)
            {
                return Response<bool>.Fail($"An error occurred: {ex.Message}", 500);
            }
        }

        public async Task<Response<bool>> UpdateCouponAsync(int id, UpdateCouponDto couponDto)
        {
            try
            {
                var existingCoupon = await couponRepository.GetByIdAsync(id);

                if (existingCoupon == null)
                {
                    return Response<bool>.Fail("CouponController not found", 404);
                }

                var couponEntity = mapper.Map<Coupon>(couponDto);
                await couponRepository.UpdateAsync(id, couponEntity);
                return Response<bool>.Succes(true, 200);
            }
            catch (Exception ex)
            {
                return Response<bool>.Fail($"An error occurred: {ex.Message}", 500);
            }
        }

        public async Task<Response<bool>> DeleteCouponAsync(int id)
        {
            try
            {
                var existingCoupon = await couponRepository.GetByIdAsync(id);

                if (existingCoupon == null)
                {
                    return Response<bool>.Fail("CouponController not found", 404);
                }

                await couponRepository.DeleteAsync(id);
                return Response<bool>.Succes(true, 200);
            }
            catch (Exception ex)
            {
                return Response<bool>.Fail($"An error occurred: {ex.Message}", 500);
            }
        }
    }
}
