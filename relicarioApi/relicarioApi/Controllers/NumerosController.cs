using MediatR;
using Microsoft.AspNetCore.Mvc;
using relicarioApi.Domain.Commands.Requests.Home.Numeros;
using relicarioApi.Domain.Commands.Responses.Home.Numeros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace relicarioApi.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]

    public class NumerosController : ControllerBase
    {

        [HttpGet]
        [Produces(typeof(GetNumerosResponse))]
        public async Task<IActionResult> Get([FromServices] IMediator handler,
            [FromQuery] GetNumerosRequest request)
        {
            var result = await handler.Send(request);
            return result.Sucess ? Ok(result) : NotFound(result);
        }

        [HttpPost]
        [Produces(typeof(CreateNumerosResponse))]
        public async Task<IActionResult> Create([FromServices] IMediator handler,
            [FromBody] CreateNumerosRequest request)
        {
            var response = await handler.Send(request);
            return response.Sucess ? CreatedAtAction(nameof(Get), response) : BadRequest(response);
        }

        [HttpPut("{id}")]
        [Produces(typeof(ChangeNumerosResponse))]
        public async Task<IActionResult> Put(Guid id, [FromServices] IMediator handler,
            [FromBody] ChangeNumerosRequest request)
        {
            request.Id = id;
            var response = await handler.Send(request);
            return response.Sucess ? NoContent() : NotFound(response);
        }


        [HttpDelete]
        [Produces(typeof(DeleteNumerosResponse))]
        public async Task<IActionResult> Delete([FromServices] IMediator handler,
            [FromQuery] DeleteNumerosRequest request)
        {
            var response = await handler.Send(request);
            return response.Sucess ? NoContent() : NotFound(response);
        }
    }
}
