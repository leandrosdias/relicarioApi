using MediatR;
using Microsoft.AspNetCore.Mvc;
using relicarioApi.Domain.Commands.Requests.Loja.ProdutoAtributo;
using relicarioApi.Domain.Commands.Requests.ProdutoLojaAtributo;
using relicarioApi.Domain.Commands.Responses.Loja.ProdutoAtributos;
using relicarioApi.Domain.Commands.Responses.ProdutoLojaAtributo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace relicarioApi.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]

    public class ProdutoLojaAtributoController : ControllerBase
    {

        [HttpGet]
        [Produces(typeof(GetProdutoLojaAtributoResponse))]
        public async Task<IActionResult> Get([FromServices] IMediator handler,
            [FromQuery] GetProdutoLojaAtributoRequest request)
        {
            var result = await handler.Send(request);
            return result.Sucess ? Ok(result) : NotFound(result);
        }

        [HttpPost]
        [Produces(typeof(CreateProdutoLojaAtributoResponse))]
        public async Task<IActionResult> Create([FromServices] IMediator handler,
            [FromBody] CreateProdutoLojaAtributoRequest request)
        {
            var response = await handler.Send(request);
            return response.Sucess ? CreatedAtAction(nameof(Get), response) : BadRequest(response);
        }

        [HttpPut("{id}")]
        [Produces(typeof(ChangeProdutoLojaAtributoResponse))]
        public async Task<IActionResult> Put(Guid id, [FromServices] IMediator handler,
            [FromBody] ChangeProdutoLojaAtributoRequest request)
        {
            request.Id = id;
            var response = await handler.Send(request);
            return response.Sucess ? NoContent() : NotFound(response);
        }


        [HttpDelete]
        [Produces(typeof(DeleteProdutoLojaAtributoResponse))]
        public async Task<IActionResult> Delete([FromServices] IMediator handler,
            [FromQuery] DeleteProdutoLojaAtributoRequest request)
        {
            var response = await handler.Send(request);
            return response.Sucess ? NoContent() : NotFound(response);
        }

        [HttpPost]
        [Route("List")]
        [Produces(typeof(ChangeListProdutoAtributoResponse))]
        public async Task<IActionResult> UpdateList([FromServices] IMediator handler,
            [FromBody] ChangeListProdutoAtributoRequest request)
        {
            var response = await handler.Send(request);
            return response.Sucess ? NoContent() : NotFound(response);
        }
    }
}
