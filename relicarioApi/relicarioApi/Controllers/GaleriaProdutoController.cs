using MediatR;
using Microsoft.AspNetCore.Mvc;
using relicarioApi.Domain.Commands.Requests.Galeria.Produtos;
using relicarioApi.Domain.Commands.Responses.Galeria.Produtos;
using System;
using System.Threading.Tasks;

namespace relicarioApi.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]

    public class GaleriaProdutoController : ControllerBase
    {

        [HttpGet]
        [Produces(typeof(GetGaleriaProdutoResponse))]
        public async Task<IActionResult> Get([FromServices] IMediator handler,
            [FromQuery] GetGaleriaProdutoRequest request)
        {
            var result = await handler.Send(request);
            return result.Sucess ? Ok(result) : NotFound(result);
        }

        [HttpPost]
        [Produces(typeof(CreateGaleriaProdutoResponse))]
        public async Task<IActionResult> Create([FromServices] IMediator handler,
            [FromBody] CreateGaleriaProdutoRequest request)
        {
            var response = await handler.Send(request);
            return response.Sucess ? CreatedAtAction(nameof(Get), response) : BadRequest(response);
        }

        [HttpPut("{id}")]
        [Produces(typeof(ChangeGaleriaProdutoResponse))]
        public async Task<IActionResult> Put(Guid id, [FromServices] IMediator handler,
            [FromBody] ChangeGaleriaProdutoRequest request)
        {
            request.Id = id;
            var response = await handler.Send(request);
            return response.Sucess ? NoContent() : NotFound(response);
        }


        [HttpDelete]
        [Produces(typeof(DeleteGaleriaProdutoResponse))]
        public async Task<IActionResult> Delete([FromServices] IMediator handler,
            [FromQuery] DeleteGaleriaProdutoRequest request)
        {
            var response = await handler.Send(request);
            return response.Sucess ? NoContent() : NotFound(response);
        }
    }
}
