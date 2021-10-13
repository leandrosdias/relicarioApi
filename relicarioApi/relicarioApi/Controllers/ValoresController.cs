using MediatR;
using Microsoft.AspNetCore.Mvc;
using relicarioApi.Domain.Commands.Requests.Home.Valores;
using relicarioApi.Domain.Commands.Responses.Home.Valores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace relicarioApi.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]

    public class ValoresController : ControllerBase
    {

        [HttpGet]
        [Produces(typeof(GetValoresResponse))]
        public async Task<IActionResult> Get([FromServices] IMediator handler,
            [FromQuery] GetValoresRequest request)
        {
            var result = await handler.Send(request);
            return result.Sucess ? Ok(result) : NotFound(result);
        }

        [HttpPost]
        [Produces(typeof(CreateValoresResponse))]
        public async Task<IActionResult> Create([FromServices] IMediator handler,
            [FromBody] CreateValoresRequest request)
        {
            var response = await handler.Send(request);
            return response.Sucess ? CreatedAtAction(nameof(Get), response) : BadRequest(response);
        }

        [HttpPut("{id}")]
        [Produces(typeof(ChangeValoresResponse))]
        public async Task<IActionResult> Put(Guid id, [FromServices] IMediator handler,
            [FromBody] ChangeValoresRequest request)
        {
            request.Id = id;
            var response = await handler.Send(request);
            return response.Sucess ? NoContent() : NotFound(response);
        }


        [HttpDelete]
        [Produces(typeof(DeleteValoresResponse))]
        public async Task<IActionResult> Delete([FromServices] IMediator handler,
            [FromQuery] DeleteValoresRequest request)
        {
            var response = await handler.Send(request);
            return response.Sucess ? NoContent() : NotFound(response);
        }
    }
}
