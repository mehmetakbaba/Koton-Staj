using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koton.Order.Aplication.Features.Mediator.Queries.OrderingQueries;
using Koton.Order.Aplication.Features.Mediator.Results.OrderingResults;
using Koton.Order.Aplication.Interfaces;
using Koton.Order.Domain.Entities;
using Koton.Order.Domain.Entities.Concrete;
using MediatR;

namespace Koton.Order.Aplication.Features.Mediator.Handlers.OrderingHandlers
{
    public class GetOrderingQueryHandler(IRepository<Ordering> repository) : IRequestHandler<GetOrderingQuery,List<GetOrderingQueryResult>>
    {
        private readonly IRepository<Ordering> _repository = repository;
        public async Task<List<GetOrderingQueryResult>> Handle(GetOrderingQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetOrderingQueryResult()
            {
                Id = x.Id,
                OrderDate = x.OrderDate,
                TotalPrice = x.TotalPrice,
                UserId = x.UserId
            }).ToList();
        }
    }
}
