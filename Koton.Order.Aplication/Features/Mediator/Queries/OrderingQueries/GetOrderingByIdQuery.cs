using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koton.Order.Aplication.Features.Mediator.Results.OrderingResults;
using MediatR;

namespace Koton.Order.Aplication.Features.Mediator.Queries.OrderingQueries
{
    public class GetOrderingByIdQuery(int id):IRequest<GetOrderingQueryResult>, IRequest<GetOrderingByIdQueryResult>
    {
        public int Id { get; set; } = id;

    }
}
