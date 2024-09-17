using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koton.Catalog.Entity.Entities.Abstract;

namespace Koton.Order.Domain.Entities
{
    public class OrderDetail : IEntity<int>
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } = default!;
        public decimal ProductPrice { get; set; }
        public int ProductAmount { get; set; }
        public decimal ProductTotalPrice { get; set; }
        public int OrderingId { get; set; }
        public Ordering Ordering { get; set; }
    }
}
