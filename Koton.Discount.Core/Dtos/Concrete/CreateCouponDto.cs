
using Koton.Discount.Core.Dtos.Abstract;

namespace Koton.Discount.Core.Dtos.Concrete
{
    public class CreateCouponDto : IDto
    {
        public string Code { get; set; }
        public int Rate { get; set; }
        public bool IsActive { get; set; }
        public DateTime ValidDate { get; set; }
    }
}
