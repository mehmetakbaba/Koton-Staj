using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koton.Order.Aplication.Features.Mediator.Results.OrderingResults
{
    public class GetOrderingQueryResult
    {
        public int Id { get; set; }
        public string UserId { get; set; } = default!;
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
