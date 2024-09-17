using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koton.Discount.Core.Dtos.Abstract;

namespace Koton.Discount.Core.Dtos.Concrete
{
    public class UpdateCouponDto : IDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int Rate { get; set; }
        public bool IsActive { get; set; }
        public DateTime ValidDate { get; set; }
    }
}
