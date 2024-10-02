using Koton.Order.Aplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koton.Order.Domain.Entities;
using Koton.Order.Aplication.Features.CQRS.Commands.OrderDetailCommands;
using Koton.Order.Domain.Entities.Concrete;

namespace Koton.Order.Aplication.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class CreateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
    {
        private readonly IRepository<OrderDetail> _repository = repository;
        public async Task Handle(CreateOrdeDetailCommand command)
        {
            await _repository.CreateAsync(
                new OrderDetail()
                {
                    ProductAmount = command.ProductAmount,
                    ProductName = command.ProductName,
                    Id = command.Id,
                    ProductId = command.ProductId,
                    ProductPrice = command.ProductPrice,
                    UserId = command.UserId,
                    Address = command.Address,
                    ProductTotalPrice = command.ProductTotalPrice,
                });
        }
    }
}
