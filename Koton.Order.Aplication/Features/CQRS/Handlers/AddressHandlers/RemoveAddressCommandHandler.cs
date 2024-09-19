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
    public class RemoveAddressCommandHandler(IRepository<Address> repository)
    {
        private readonly IRepository<Address> _repository = repository;

        public async Task Handle(RemoveAddressCommand command)
        {
            var values = await _repository.GetByIdAsync(command.Id);
            await _repository.DeleteAsync(values);
        }
    }
}
