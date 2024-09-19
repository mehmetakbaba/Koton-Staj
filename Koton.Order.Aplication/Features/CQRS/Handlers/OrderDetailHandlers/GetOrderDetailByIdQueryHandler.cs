using Koton.Order.Aplication.Features.CQRS.Queries.AddressQueries;
using Koton.Order.Aplication.Features.CQRS.Queries.OrderDetailQueries;
using Koton.Order.Aplication.Features.CQRS.Results.AddressResults;
using Koton.Order.Aplication.Features.CQRS.Results.OrderDetailResults;
using Koton.Order.Aplication.Interfaces;
using Koton.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koton.Order.Domain.Entities.Concrete;

namespace Koton.Order.Aplication.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailByIdQueryHandler(IRepository<OrderDetail> repository)
    {
        private readonly IRepository<OrderDetail> _repository = repository;
        public async Task<GetOrderDetailByIdQueryResult> Handle(GetOrderDetailByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetOrderDetailByIdQueryResult()
            {
                ProductId = values.ProductId,
                ProductPrice = values.ProductPrice,
                ProductTotalPrice = values.ProductTotalPrice,
                OrderingId = values.OrderingId,
                ProductAmount = values.ProductAmount,
                ProductName = values.ProductName,
                Id = values.Id,
                
            };
        }
    }
}
