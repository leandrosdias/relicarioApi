using relicarioApi.Models;
using System.Threading.Tasks;

namespace relicarioApi.Services.Correio
{
    public interface IConsumeCorreioFrete
    {
        Task<string> CalculaPrecoFrete(string cepOrigem, string cepDestino, string codServico, ProdutoLoja produto);
    }
}
