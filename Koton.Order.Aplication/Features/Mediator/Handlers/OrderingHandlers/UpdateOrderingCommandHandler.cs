using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koton.Order.Aplication.Features.Mediator.Commands.OrderingCommands;
using Koton.Order.Aplication.Interfaces;
using Koton.Order.Domain.Entities;
using MediatR;

namespace Koton.Order.Aplication.Features.Mediator.Handlers.OrderingHandlers
{
    public class UpdateOrderingCommandHandler(IRepository<Ordering> repository) : IRequestHandler<UpdateOrderingCommand>
    {
        private readonly IRepository<Ordering> _repository = repository;
        public async Task Handle(UpdateOrderingCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            values.OrderDate = request.OrderDate;
            values.UserId= request.UserId;
            values.TotalPrice = request.TotalPrice;
            await _repository.UpdateAsync(values);
        }
    }
}
