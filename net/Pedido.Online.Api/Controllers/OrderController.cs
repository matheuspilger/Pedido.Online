using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pedido.Online.Application.Commands.Orders.Actions.Commands;
using Pedido.Online.Application.Commands.Orders.Actions.Queries;

namespace Pedido.Online.Api.Controllers
{
    public class OrderController(IMediator mediator) : ApiController
    {
        [HttpPost(nameof(Insert))]
        public async Task<IActionResult> Insert([FromBody] OrderInsertCommand command)
        {
            var result = await mediator.Send(command);
            return CustomResponse(result);
        }

        [HttpPut(nameof(Update))]
        public async Task<IActionResult> Update([FromBody] OrderUpdateCommand command)
        {
            var result = await mediator.Send(command);
            return CustomResponse(result);
        }

        [HttpDelete(nameof(Delete))]
        public async Task<IActionResult> Delete([FromQuery] OrderDeleteCommand command)
        {
            var result = await mediator.Send(command);
            return CustomResponse(result);
        }

        [HttpGet(nameof(Get))]
        public async Task<IActionResult> Get([FromQuery] OrderGetByIdQuery query)
        {
            var result = await mediator.Send(query);
            return CustomResponse(result);
        }

        [HttpGet(nameof(GetAll))]
        public async Task<IActionResult> GetAll([FromQuery] OrderGetAllQuery query)
        {
            var result = await mediator.Send(query);
            return CustomResponse(result);
        }
    }
}
