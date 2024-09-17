using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koton.Order.Aplication.Features.CQRS.Results.OrderDetailResults;
using Koton.Order.Aplication.Interfaces;
using Koton.Order.Domain.Entities;

namespace Koton.Order.Aplication.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailQueryHandler(IRepository<OrderDetail> repository)
    {
        private readonly IRepository<OrderDetail> _repository = repository;

        public async Task<List<GetOrderDetailQueryResult>> Handle()
        {
            var values = await repository.GetAllAsync();
            return values.Select(x => new GetOrderDetailQueryResult()
            {
                Id = x.Id,
                ProductAmount = x.ProductAmount,
                OrderingId = x.OrderingId,
                ProductName = x.ProductName,
                ProductId = x.ProductId,
                ProductPrice = x.ProductPrice,
                ProductTotalPrice = x.ProductTotalPrice
            }).ToList();
        }
    }
}
