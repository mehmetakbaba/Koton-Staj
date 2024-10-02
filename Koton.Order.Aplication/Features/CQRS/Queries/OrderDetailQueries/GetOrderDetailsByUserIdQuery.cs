using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koton.Order.Aplication.Features.CQRS.Queries.OrderDetailQueries
{
    public class GetOrderDetailsByUserIdQuery(string userId)
    {
        public string UserId { get; set; } = userId;
    }
}
