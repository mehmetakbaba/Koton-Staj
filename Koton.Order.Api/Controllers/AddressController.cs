using Koton.Order.Aplication.Features.CQRS.Commands.AddressCommands;
using Koton.Order.Aplication.Features.CQRS.Handlers.AddressHandlers;
using Koton.Order.Aplication.Features.CQRS.Queries.AddressQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Koton.Order.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController(GetAddressQueryHandler getAddressQueryHandler, GetAddressByIdQueryHandler getAddressByIdQueryHandler,
        UpdateAddressCommandHandler updateAddressCommandHandler,RemoveAddressCommandHandler removeAddressCommandHandler,
        CreateAddressCommandHandler createAddressCommandHandler) : ControllerBase
    {
        private readonly GetAddressQueryHandler _getAddressQueryHandler = getAddressQueryHandler;
        private readonly GetAddressByIdQueryHandler _getAddressByIdQueryHandler = getAddressByIdQueryHandler;
        private readonly UpdateAddressCommandHandler _updateAddressCommandHandler = updateAddressCommandHandler;
        private readonly RemoveAddressCommandHandler _removeAddressCommandHandler = removeAddressCommandHandler;
        private readonly CreateAddressCommandHandler _createAddressCommandHandler = createAddressCommandHandler;

        [HttpGet]
        public async Task<IActionResult> AddressList()
        {
            var values =await _getAddressQueryHandler.Handle();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAddressById(int id)
        {
            var values = await _getAddressByIdQueryHandler.Handle(new GetAddressByIdQuery(id));
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAddress(CreateAddressCommand command)
        {
            await _createAddressCommandHandler.Handle(command);
            return Ok("Address has been successfully created.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAdress(UpdateAddressCommand command)
        {
            await _updateAddressCommandHandler.Handler(command);
            return Ok("Address has been successfully updated.");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveAddress(int id)
        {
            await _removeAddressCommandHandler.Handle(new RemoveAddressCommand(id));
            return Ok("Address has been successfully remove.");

        }
    }
}
