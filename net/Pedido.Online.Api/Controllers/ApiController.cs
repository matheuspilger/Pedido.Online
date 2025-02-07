using Microsoft.AspNetCore.Mvc;
using Pedido.Online.Domain.Core.Bases.Interfaces;

namespace Pedido.Online.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class ApiController : ControllerBase
    {
        protected ActionResult CustomResponse(IResponseResult responseResult)
        {
            if (responseResult.StatusCode == StatusCodes.Status200OK)
                return Ok(responseResult.Result);

            return BadRequest(responseResult.Validation);
        }
    }
}
