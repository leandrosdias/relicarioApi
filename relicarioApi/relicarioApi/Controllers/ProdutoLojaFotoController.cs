using MediatR;
using Microsoft.AspNetCore.Mvc;
using relicarioApi.Domain.Commands.Requests.Loja.ProdutoFoto;
using relicarioApi.Domain.Commands.Responses.Loja.ProdutoFoto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace relicarioApi.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]

    public class ProdutoLojaFotoController : ControllerBase
    {

        [HttpGet]
        [Produces(typeof(GetProdutoLojaFotoResponse))]
        public async Task<IActionResult> Get([FromServices] IMediator handler,
            [FromQuery] GetProdutoLojaFotoRequest request)
        {
            var result = await handler.Send(request);
            return result.Sucess ? Ok(result) : NotFound(result);
        }

        [HttpPost]
        [Produces(typeof(CreateProdutoLojaFotoResponse))]
        public async Task<IActionResult> Create([FromServices] IMediator handler,
            [FromBody] CreateProdutoLojaFotoRequest request)
        {
            var response = await handler.Send(request);
            return response.Sucess ? CreatedAtAction(nameof(Get), response) : BadRequest(response);
        }

        [HttpPost]
        [Route("List")]
        [Produces(typeof(ChangeListProdutoFotoResponse))]
        public async Task<IActionResult> UpdateList([FromServices] IMediator handler,
            [FromBody] ChangeListProdutoFotoRequest request)
        {
            var response = await handler.Send(request);
            return response.Sucess ? NoContent() : NotFound(response);
        }

        [HttpPut("{id}")]
        [Produces(typeof(ChangeProdutoLojaFotoResponse))]
        public async Task<IActionResult> Put(Guid id, [FromServices] IMediator handler,
            [FromBody] ChangeProdutoLojaFotoRequest request)
        {
            request.Id = id;
            var response = await handler.Send(request);
            return response.Sucess ? NoContent() : NotFound(response);
        }


        [HttpDelete]
        [Produces(typeof(DeleteProdutoLojaFotoResponse))]
        public async Task<IActionResult> Delete([FromServices] IMediator handler,
            [FromQuery] DeleteProdutoLojaFotoRequest request)
        {
            var response = await handler.Send(request);
            return response.Sucess ? NoContent() : NotFound(response);
        }
    }
}
