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
    public class UpdateAddressCommandHandler(IRepository<Address> repository)
    {
        private readonly IRepository<Address> _repository = repository;

        public async Task Handler(UpdateAddressCommand command)
        {
            var values = await _repository.GetByIdAsync(command.Id);
            values.Detail = command.Detail;
            values.City = command.City;
            values.District = command.District;
            values.UserId = command.UserId;
            await _repository.UpdateAsync(values);
        }
    }
}
