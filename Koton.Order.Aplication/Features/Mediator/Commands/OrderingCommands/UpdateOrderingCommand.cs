using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Koton.Order.Aplication.Features.Mediator.Commands.OrderingCommands
{
    public class UpdateOrderingCommand : IRequest
    {
        public int Id { get; set; }
        public string UserId { get; set; } = default!;
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
