using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koton.Order.Aplication.Features.CQRS.Results.OrderDetailResults
{
    public class GetOrderDetailsByUserIdResult
    {
        public int Id { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; } = default!;
        public decimal ProductPrice { get; set; }
        public int ProductAmount { get; set; }
        public decimal ProductTotalPrice { get; set; }
        public string UserId { get; set; }
        public string Address { get; set; }
    }
}
