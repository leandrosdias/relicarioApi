using MediatR;
using Microsoft.AspNetCore.Mvc;
using relicarioApi.Domain.Commands.Requests.ProdutoLoja;
using relicarioApi.Domain.Commands.Responses.ProdutoLoja;
using relicarioApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace relicarioApi.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]

    public class ProdutoLojaController : ControllerBase
    {
        private readonly IProdutoLojaRepository _repository;

        public ProdutoLojaController(IProdutoLojaRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Produces(typeof(GetProdutoLojaResponse))]
        public async Task<IActionResult> Get([FromServices] IMediator handler,
            [FromQuery] GetProdutoLojaRequest request)
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

        [HttpGet]
        [Route("ProdutosSelect")]
        public IActionResult Get()
        {
            var res = _repository.GetProdutoSelect();
            return res == null || res.Count() <= 0 ? NotFound() : Ok(res);
        }

        [HttpPost]
        [Produces(typeof(CreateProdutoLojaResponse))]
        public async Task<IActionResult> Create([FromServices] IMediator handler,
            [FromBody] CreateProdutoLojaRequest request)
        {
            var response = await handler.Send(request);
            return response.Sucess ? CreatedAtAction(nameof(Get), response) : BadRequest(response);
        }

        [HttpPut("{id}")]
        [Produces(typeof(ChangeProdutoLojaResponse))]
        public async Task<IActionResult> Put(Guid id, [FromServices] IMediator handler,
            [FromBody] ChangeProdutoLojaRequest request)
        {
            request.Id = id;
            var response = await handler.Send(request);
            return response.Sucess ? NoContent() : NotFound(response);
        }


        [HttpDelete]
        [Produces(typeof(DeleteProdutoLojaResponse))]
        public async Task<IActionResult> Delete([FromServices] IMediator handler,
            [FromQuery] DeleteProdutoLojaRequest request)
        {
            var response = await handler.Send(request);
            return response.Sucess ? NoContent() : NotFound(response);
        }
    }
}
