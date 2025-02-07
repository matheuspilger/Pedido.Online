using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pedido.Online.Application.Commands.Products.Actions.Commands;
using Pedido.Online.Application.Commands.Products.Actions.Queries;

namespace Pedido.Online.Api.Controllers
{
    public class ProductController(IMediator mediator) : ApiController
    {
        [HttpPost(nameof(Insert))]
        public async Task<IActionResult> Insert([FromBody] ProductInsertCommand command)
        {
            var result = await mediator.Send(command);
            return CustomResponse(result);
        }

        [HttpPut(nameof(Update))]
        public async Task<IActionResult> Update([FromBody] ProductUpdateCommand command)
        {
            var result = await mediator.Send(command);
            return CustomResponse(result);
        }

        [HttpDelete(nameof(Delete))]
        public async Task<IActionResult> Delete([FromQuery] ProductDeleteCommand command)
        {
            var result = await mediator.Send(command);
            return CustomResponse(result);
        }

        [HttpGet(nameof(Get))]
        public async Task<IActionResult> Get([FromQuery] ProductGetByIdQuery query)
        {
            var result = await mediator.Send(query);
            return CustomResponse(result);
        }

        [HttpGet(nameof(GetAll))]
        public async Task<IActionResult> GetAll([FromQuery] ProductGetAllQuery query)
        {
            var result = await mediator.Send(query);
            return CustomResponse(result);
        }
    }
}
