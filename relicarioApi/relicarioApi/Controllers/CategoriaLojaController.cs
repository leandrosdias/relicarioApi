using MediatR;
using Microsoft.AspNetCore.Mvc;
using relicarioApi.Data;
using relicarioApi.Domain.Commands.Requests.CategoriaLoja;
using relicarioApi.Domain.Commands.Responses.CategoriaLoja;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace relicarioApi.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]

    public class CategoriaLojaController : ControllerBase
    {

        [HttpGet]
        [Produces(typeof(GetCategoriaLojaResponse))]
        public async Task<IActionResult> Get([FromServices] IMediator handler,
            [FromQuery] GetCategoriaLojaRequest request)
        {

            if (request.Codigos != null)
            {
                request.Codigos = request.Codigos.Where(x => x != null).ToList();

                var resultCods = new List<string>();

                foreach (var cod in request.Codigos)
                {
                    resultCods.AddRange(cod.Split(','));
                }

                request.Codigos = resultCods;
            }

            var result = await handler.Send(request);
            return result.Sucess ? Ok(result) : NotFound(result);
        }

        [HttpPost]
        [Produces(typeof(CreateCategoriaLojaResponse))]
        public async Task<IActionResult> Create([FromServices] IMediator handler,
            [FromBody] CreateCategoriaLojaRequest request)
        {
            var response = await handler.Send(request);
            return response.Sucess ? CreatedAtAction(nameof(Get), response) : BadRequest(response);
        }

        [HttpPut("{id}")]
        [Produces(typeof(ChangeCategoriaLojaResponse))]
        public async Task<IActionResult> Put(Guid id, [FromServices] IMediator handler,
            [FromBody] ChangeCategoriaLojaRequest request)
        {
            request.Id = id;
            var response = await handler.Send(request);
            return response.Sucess ? NoContent() : NotFound(response);
        }


        [HttpDelete]
        [Produces(typeof(DeleteCategoriaLojaResponse))]
        public async Task<IActionResult> Delete([FromServices] IMediator handler,
            [FromQuery] DeleteCategoriaLojaRequest request)
        {
            var response = await handler.Send(request);
            return response.Sucess ? NoContent() : NotFound(response);
        }
    }
}
