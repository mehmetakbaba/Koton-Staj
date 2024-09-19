using AutoMapper;

using Koton.Discount.Core.Dtos.Concrete;
using Koton.Discount.Entity.Entities.Concrete;

namespace Koton.Discount.Business.Mappings
{
    public class GeneralMapper : Profile
    {
        public GeneralMapper()
        {
            CreateMap<Coupon, CreateCouponDto>().ReverseMap();
            CreateMap<Coupon, GetByIdCouponDto>().ReverseMap();
            CreateMap<Coupon, ResultCouponDto>().ReverseMap();
            CreateMap<Coupon, UpdateCouponDto>().ReverseMap();
        }
    }
}
