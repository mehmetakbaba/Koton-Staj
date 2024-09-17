using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koton.Order.Aplication.Features.Mediator.Commands.OrderingCommands;
using Koton.Order.Aplication.Interfaces;
using Koton.Order.Domain.Entities;

namespace Koton.Order.Aplication.Features.Mediator.Handlers.OrderingHandlers
{
    public class CreateOrderingCommandHandler(IRepository<Ordering> repository) : IRequestHandler<CreateOrderingCommand>
    {
        private readonly IRepository<Ordering> _repository = repository;
        public async Task Handle(CreateOrderingCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Ordering
            {
                OrderDate = request.OrderDate,
                TotalPrice = request.TotalPrice,
                UserId = request.UserId,
            });
        }
    }
}
