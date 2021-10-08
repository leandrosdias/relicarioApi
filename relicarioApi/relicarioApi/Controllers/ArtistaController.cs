using MediatR;
using Microsoft.AspNetCore.Mvc;
using relicarioApi.Domain.Commands.Requests.Galeria.Artistas;
using relicarioApi.Domain.Commands.Responses.Galeria.Artistas;
using System;
using System.Threading.Tasks;

namespace relicarioApi.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]

    public class ArtistaController : ControllerBase
    {

        [HttpGet]
        [Produces(typeof(GetArtistaResponse))]
        public async Task<IActionResult> Get([FromServices] IMediator handler,
            [FromQuery] GetArtistaRequest request)
        {
            var result = await handler.Send(request);
            return result.Sucess ? Ok(result) : NotFound(result);
        }

        [HttpPost]
        [Produces(typeof(CreateArtistaResponse))]
        public async Task<IActionResult> Create([FromServices] IMediator handler,
            [FromBody] CreateArtistaRequest request)
        {
            var response = await handler.Send(request);
            return response.Sucess ? CreatedAtAction(nameof(Get), response) : BadRequest(response);
        }

        [HttpPut("{id}")]
        [Produces(typeof(ChangeArtistaResponse))]
        public async Task<IActionResult> Put(Guid id, [FromServices] IMediator handler,
            [FromBody] ChangeArtistaRequest request)
        {
            request.Id = id;
            var response = await handler.Send(request);
            return response.Sucess ? NoContent() : NotFound(response);
        }


        [HttpDelete]
        [Produces(typeof(DeleteArtistaResponse))]
        public async Task<IActionResult> Delete([FromServices] IMediator handler,
            [FromQuery] DeleteArtistaRequest request)
        {
            var response = await handler.Send(request);
            return response.Sucess ? NoContent() : NotFound(response);
        }
    }
}
