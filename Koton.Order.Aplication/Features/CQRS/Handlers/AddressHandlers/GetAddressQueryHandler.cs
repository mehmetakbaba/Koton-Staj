using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koton.Order.Aplication.Features.CQRS.Results.AddressResults;
using Koton.Order.Aplication.Interfaces;
using Koton.Order.Domain.Entities;

namespace Koton.Order.Aplication.Features.CQRS.Handlers.AddressHandlers
{
    public class GetAddressQueryHandler(IRepository<Address> repository)
    {
        private readonly IRepository<Address> _repository = repository;

        public async Task<List<GetAddressQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetAddressQueryResult()
            {
                City = x.City,
                Detail = x.Detail,
                District = x.District,
                UserId = x.UserId,
                Id = x.Id
            }).ToList();
        }
    }
}
