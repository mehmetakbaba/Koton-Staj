using Koton.Order.Aplication.Features.CQRS.Commands.OrderDetailCommands;
using Koton.Order.Aplication.Features.CQRS.Handlers.OrderDetailHandlers;
using Koton.Order.Aplication.Features.CQRS.Queries.OrderDetailQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Koton.Order.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController(
        GetOrderDetailByIdQueryHandler getOrderDetailByIdQueryHandler,
        GetOrderDetailQueryHandler getOrderDetailQueryHandler,
        CreateOrderDetailCommandHandler createOrderDetailCommandHandler,
        RemoveOrderDetailCommandHandler removeOrderDetailCommandHandler,
        UpdateOrderDetailCommandHandler updateOrderDetailCommandHandler)
        : ControllerBase
    {
        private readonly GetOrderDetailByIdQueryHandler _getOrderDetailByIdQueryHandler = getOrderDetailByIdQueryHandler;
        private readonly GetOrderDetailQueryHandler  _getOrderDetailQueryHandler = getOrderDetailQueryHandler;
        private readonly CreateOrderDetailCommandHandler _createOrderDetailCommandHandler = createOrderDetailCommandHandler;
        private readonly RemoveOrderDetailCommandHandler _removeOrderDetailCommandHandler = removeOrderDetailCommandHandler;
        private readonly UpdateOrderDetailCommandHandler _updateOrderDetailCommandHandler = updateOrderDetailCommandHandler;

        [HttpGet]
        public async Task<IActionResult> OrderDetailList()
        {
            var values = await _getOrderDetailQueryHandler.Handle();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderDetailById(int id)
        {
            var value = await _getOrderDetailByIdQueryHandler.Handle(new GetOrderDetailByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrderDetail(CreateOrdeDetailCommand command)
        {
            await _createOrderDetailCommandHandler.Handle(command);
            return Ok("Address Detail has been successfully created.");

        }
        [HttpDelete]
        public async Task<IActionResult> RemoveOrderDetail(int id)
        {
            await _removeOrderDetailCommandHandler.Handle(new RemoveOrderDetailCommand(id));
            return Ok("Address Detail has been successfully remove.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateOrderDetail(UpdateOrderDetailCommand command)
        {
            await _updateOrderDetailCommandHandler.Handler(command);
            return Ok("Address Detail has been successfully update.");
        }
    }
}
