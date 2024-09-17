using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koton.Order.Aplication.Features.Mediator.Queries.OrderingQueries;
using Koton.Order.Aplication.Features.Mediator.Results.OrderingResults;
using Koton.Order.Aplication.Interfaces;
using Koton.Order.Domain.Entities;
using MediatR;

namespace Koton.Order.Aplication.Features.Mediator.Handlers.OrderingHandlers
{
    public class GetOrderingByIdQueryHandler(IRepository<Ordering> repository): IRequestHandler<GetOrderingByIdQuery,GetOrderingByIdQueryResult>
    {
        private readonly IRepository<Ordering> _repository = repository;
        public async Task<GetOrderingByIdQueryResult> Handle(GetOrderingByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetOrderingByIdQueryResult
            {
                Id = values.Id,
                OrderDate = values.OrderDate,
                TotalPrice = values.TotalPrice,
                UserId = values.UserId
            };
        }
    }
}
