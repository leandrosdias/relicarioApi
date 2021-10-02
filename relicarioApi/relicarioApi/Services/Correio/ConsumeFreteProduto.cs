using relicarioApi.Models;
using System.Text.Json;
using System.Threading.Tasks;

namespace relicarioApi.Services.Correio
{
    public class ConsumeFreteProduto : IConsumeCorreioFrete
    {
        public async Task<string> CalculaPrecoFrete(string cepOrigem, string cepDestino, string codServico, ProdutoLoja produto)
        {
            var client = new CorreioWS.CalcPrecoPrazoWSSoapClient(CorreioWS.CalcPrecoPrazoWSSoapClient.EndpointConfiguration.CalcPrecoPrazoWSSoap);
            CorreioWS.cResultado resp = await client.CalcPrecoPrazoAsync("", "", codServico, cepOrigem, cepDestino, produto.Peso, 1, produto.Comprimento, produto.Altura, produto.Largura, 0, "N", 0, "N");

            var serv = resp.Servicos[0];
            return JsonSerializer.Serialize(serv);
        }
    }
}
