using Koton.Order.Aplication.Features.CQRS.Handlers.OrderDetailHandlers;
using Koton.Order.Aplication.Features.Mediator.Commands.OrderingCommands;
using Koton.Order.Aplication.Features.Mediator.Queries.OrderingQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Koton.Order.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderingController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> OrderingList()
        {
            var values = await _mediator.Send(new GetOrderingQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderingById(int id)
        {
            var values = await _mediator.Send(new GetOrderingByIdQuery(id));
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrdering(CreateOrderingCommand command)
        {
            await _mediator.Send(command);
            return Ok("Ordering  has been successfully created.");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveOrdering(int id)
        {
            await _mediator.Send(new RemoveOrderingCommand(id));
            return Ok("Ordering has been seccessfuly delete");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateOrdering(UpdateOrderingCommand command)
        {
            await _mediator.Send(command);
            return Ok("Ordering has been seccessfuly update");
        }
    }
}
