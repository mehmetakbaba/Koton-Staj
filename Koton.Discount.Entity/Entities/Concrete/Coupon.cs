using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koton.Discount.Entity.Entities.Abstract;


namespace Koton.Discount.Entity.Entities.Concrete
{
    public class Coupon : IEntity<int>
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int Rate { get; set; }
        public bool IsActive { get; set; }
        public DateTime ValidDate { get; set; } 
    }
}
