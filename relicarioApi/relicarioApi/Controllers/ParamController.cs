using MediatR;
using Microsoft.AspNetCore.Mvc;
using relicarioApi.Domain.Commands.Requests.System.Parameter;
using relicarioApi.Domain.Commands.Responses.System.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace relicarioApi.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]

    public class ParamController : ControllerBase
    {

        [HttpGet]
        [Produces(typeof(GetParametersResponse))]
        public async Task<IActionResult> Get([FromServices] IMediator handler,
            [FromQuery] GetParametersRequest request)
        {
            var result = await handler.Send(request);
            return result.Sucess ? Ok(result) : NotFound(result);
        }

        [HttpPost]
        [Produces(typeof(CreateParametersResponse))]
        public async Task<IActionResult> Create([FromServices] IMediator handler,
            [FromBody] CreateParametersRequest request)
        {
            var response = await handler.Send(request);
            return response.Sucess ? CreatedAtAction(nameof(Get), response) : BadRequest(response);
        }

        [HttpPut("{id}")]
        [Produces(typeof(ChangeParametersResponse))]
        public async Task<IActionResult> Put(Guid id, [FromServices] IMediator handler,
            [FromBody] ChangeParametersRequest request)
        {
            request.Id = id;
            var response = await handler.Send(request);
            return response.Sucess ? NoContent() : NotFound(response);
        }


        [HttpDelete]
        [Produces(typeof(DeleteParametersResponse))]
        public async Task<IActionResult> Delete([FromServices] IMediator handler,
            [FromQuery] DeleteParametersRequest request)
        {
            var response = await handler.Send(request);
            return response.Sucess ? NoContent() : NotFound(response);
        }
    }
}
