using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Koton.Order.Aplication.Features.CQRS.Results.OrderDetailResults;
using Koton.Order.Aplication.Interfaces;
using Koton.Order.Domain.Entities.Concrete;

namespace Koton.Order.Aplication.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailQueryHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        // Constructor
        public GetOrderDetailQueryHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        // Handle method with UserId parameter
        public async Task<List<GetOrderDetailQueryResult>> Handle(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentException("UserId is required.", nameof(userId));
            }

            // UserId'ye göre değerleri al
            var values = await _repository.GetByUserIdAsync(userId);

            return values.Select(x => new GetOrderDetailQueryResult()
            {
                Id = x.Id,
                ProductAmount = x.ProductAmount,
                UserId = x.UserId,
                Address = x.Address,
                ProductName = x.ProductName,
                ProductId = x.ProductId,
                ProductPrice = x.ProductPrice,
                ProductTotalPrice = x.ProductTotalPrice
            }).ToList();
        }
    }
}