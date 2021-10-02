using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using relicarioApi.Models;
using relicarioApi.Services.Correio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace relicarioApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CorreioController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<CorreioController> _logger;
        private readonly IConsumeCorreioFrete _consumeFrete;

        public CorreioController(ILogger<CorreioController> logger, IConsumeCorreioFrete consumeFrete)
        {
            _logger = logger;
            _consumeFrete = consumeFrete;
        }

        [HttpPost]
        public async Task<string> CalcularFreteAsync(string cepOrigem, string cepDestino, string codServico, decimal altura,
            decimal comprimento, decimal largura, string peso)
        {
            var produto = new ProdutoLoja
            {
                Altura = altura,
                Comprimento = comprimento,
                Largura = largura,
                Peso =  peso
            };

            return await _consumeFrete.CalculaPrecoFrete(cepOrigem, cepDestino, codServico, produto);
        }
    }
}
