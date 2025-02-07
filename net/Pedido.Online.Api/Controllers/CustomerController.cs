using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pedido.Online.Application.Commands.Customers.Actions.Commands;
using Pedido.Online.Application.Commands.Customers.Actions.Queries;

namespace Pedido.Online.Api.Controllers
{
    public class CustomerController(IMediator mediator) : ApiController
    {
        [HttpPost(nameof(Insert))]
        public async Task<IActionResult> Insert([FromBody] CustomerInsertCommand command)
        {
            var result = await mediator.Send(command);
            return CustomResponse(result);
        }

        [HttpPut(nameof(Update))]
        public async Task<IActionResult> Update([FromBody] CustomerUpdateCommand command)
        {
            var result = await mediator.Send(command);
            return CustomResponse(result);
        }

        [HttpDelete(nameof(Delete))]
        public async Task<IActionResult> Delete([FromQuery] CustomerDeleteCommand command)
        {
            var result = await mediator.Send(command);
            return CustomResponse(result);
        }

        [HttpGet(nameof(Get))]
        public async Task<IActionResult> Get([FromQuery] CustomerGetByIdQuery query)
        {
            var result = await mediator.Send(query);
            return CustomResponse(result);
        }

        [HttpGet(nameof(GetAll))]
        public async Task<IActionResult> GetAll([FromQuery] CustomerGetAllQuery query)
        {
            var result = await mediator.Send(query);
            return CustomResponse(result);
        }
    }
}
