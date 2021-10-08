using MediatR;
using Microsoft.AspNetCore.Mvc;
using relicarioApi.Domain.Commands.Requests;
using relicarioApi.Domain.Commands.Responses;
using relicarioApi.Domain.Handlers;
using relicarioApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace relicarioApi.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ProdutoLojaController : ControllerBase
    {
        // GET: ProdutoController
        [HttpGet]
        public IEnumerable<ProdutoLoja> RecuperarFilmes()
        {
            return new List<ProdutoLoja>
            {
                new ProdutoLoja{Nome ="Nome1"},
                new ProdutoLoja{Nome ="Nome2"},
            };
        }

        [HttpGet("{id}")]
        // GET: ProdutoController/Details/5
        public IActionResult Details(int id)
        {
            return Ok();
        }

        [HttpPost]
        // GET: ProdutoController/Create
        public Task<CreateProdutoLojaResponse> Create([FromServices] IMediator handler,
            [FromBody] CreateProdutoLojaRequest request)
        {
            return handler.Send(request);
        }

        [HttpPut]
        // GET: ProdutoController/Edit/5
        public IActionResult Edit(int id)
        {
            return Ok();
        }

        [HttpDelete]
        // GET: ProdutoController/Delete/5
        public IActionResult Delete(int id)
        {
            return Ok();
        }

    }
}
