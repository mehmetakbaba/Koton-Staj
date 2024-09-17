using Koton.Order.Aplication.Features.CQRS.Commands.OrderDetailCommands;
using Koton.Order.Aplication.Interfaces;
using Koton.Order.Domain.Entities;

namespace Koton.Order.Aplication.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class UpdateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
    {
        private readonly IRepository<OrderDetail> _repository = repository;

        public async Task Handler(UpdateOrderDetailCommand command)
        {
            var values = await _repository.GetByIdAsync(command.Id);
            values.OrderingId = command.OrderingId;
            values.ProductAmount = command.ProductAmount;
            values.ProductId = command.ProductId;
            values.ProductName = command.ProductName;
            values.ProductTotalPrice = command.ProductTotalPrice;
            values.ProductPrice = command.ProductPrice;
            await _repository.UpdateAsync(values);

        }
    }
}
