using MediatR;
using Microsoft.AspNetCore.Mvc;
using relicarioApi.Domain.Commands.Requests.Galeria.ProdutoFoto;
using relicarioApi.Domain.Commands.Responses.Galeria.ProdutoFoto;
using System;
using System.Threading.Tasks;

namespace relicarioApi.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]

    public class ProdutoGaleriaFotoController : ControllerBase
    {

        [HttpGet]
        [Produces(typeof(GetProdutoGaleriaFotoResponse))]
        public async Task<IActionResult> Get([FromServices] IMediator handler,
            [FromQuery] GetProdutoGaleriaFotoRequest request)
        {
            var result = await handler.Send(request);
            return result.Sucess ? Ok(result) : NotFound(result);
        }

        [HttpPost]
        [Produces(typeof(CreateProdutoGaleriaFotoResponse))]
        public async Task<IActionResult> Create([FromServices] IMediator handler,
            [FromBody] CreateProdutoGaleriaFotoRequest request)
        {
            var response = await handler.Send(request);
            return response.Sucess ? CreatedAtAction(nameof(Get), response) : BadRequest(response);
        }

        [HttpPut("{id}")]
        [Produces(typeof(ChangeProdutoGaleriaFotoResponse))]
        public async Task<IActionResult> Put(Guid id, [FromServices] IMediator handler,
            [FromBody] ChangeProdutoGaleriaFotoRequest request)
        {
            request.Id = id;
            var response = await handler.Send(request);
            return response.Sucess ? NoContent() : NotFound(response);
        }


        [HttpDelete]
        [Produces(typeof(DeleteProdutoGaleriaFotoResponse))]
        public async Task<IActionResult> Delete([FromServices] IMediator handler,
            [FromQuery] DeleteProdutoGaleriaFotoRequest request)
        {
            var response = await handler.Send(request);
            return response.Sucess ? NoContent() : NotFound(response);
        }

        [HttpPost]
        [Route("List")]
        [Produces(typeof(ChangeListProdutoGaleriaFotoResponse))]
        public async Task<IActionResult> UpdateList([FromServices] IMediator handler,
            [FromBody] ChangeListProdutoGaleriaFotoRequest request)
        {
            var response = await handler.Send(request);
            return response.Sucess ? NoContent() : NotFound(response);
        }
    }
}
