using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koton.Order.Aplication.Features.CQRS.Queries.AddressQueries;
using Koton.Order.Aplication.Features.CQRS.Results.AddressResults;
using Koton.Order.Aplication.Interfaces;
using Koton.Order.Domain.Entities;

namespace Koton.Order.Aplication.Features.CQRS.Handlers.AddressHandlers
{
    public class GetAddressByIdQueryHandler(IRepository<Address> repository)
    {
        private readonly IRepository<Address> _repository = repository;
        public async Task<GetAddressByIdQueryResult> Handle(GetAddressByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetAddressByIdQueryResult()
            {
                City = values.City,
                Id = values.Id,
                Detail = values.Detail,
                District = values.District,
                UserId = values.UserId
            };
        }

    }
   
}
