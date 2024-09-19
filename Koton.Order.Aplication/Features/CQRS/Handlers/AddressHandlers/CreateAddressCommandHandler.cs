using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koton.Order.Aplication.Features.CQRS.Commands.AddressCommands;
using Koton.Order.Aplication.Interfaces;
using Koton.Order.Domain.Entities;
using Koton.Order.Domain.Entities.Concrete;

namespace Koton.Order.Aplication.Features.CQRS.Handlers.AddressHandlers
{
    public class CreateAddressCommandHandler(IRepository<Address> repository)
    {
        private readonly IRepository<Address> _repository = repository;

        public async Task Handle(CreateAddressCommand createAddressCommand)
        {
            await _repository.CreateAsync(new Address
            {
                City = createAddressCommand.City,
                Detail = createAddressCommand.Detail,
                District = createAddressCommand.District,
                UserId = createAddressCommand.UserId,
                
            });
        }
    }
}
