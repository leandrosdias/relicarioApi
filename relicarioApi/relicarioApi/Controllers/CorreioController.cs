using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using relicarioApi.Models;
using relicarioApi.Services.Correio;
using System.Threading.Tasks;

namespace relicarioApi.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class CorreioController : ControllerBase
    {
        private readonly ILogger<CorreioController> _logger;
        private readonly IConsumeCorreioFrete _consumeFrete;

        public CorreioController(ILogger<CorreioController> logger, IConsumeCorreioFrete consumeFrete)
        {
            _logger = logger;
            _consumeFrete = consumeFrete;
        }

        [HttpPost]
        public async Task<string> CalcularFreteAsync(string cepOrigem, string cepDestino, string codServico, decimal altura,
            decimal comprimento, decimal largura, decimal peso)
        {
            var produto = new ProdutoLoja
            {
                Altura = altura,
                Comprimento = comprimento,
                Largura = largura,
                Peso = peso
            };

            return await _consumeFrete.CalculaPrecoFrete(cepOrigem, cepDestino, codServico, produto);
        }
    }
}
