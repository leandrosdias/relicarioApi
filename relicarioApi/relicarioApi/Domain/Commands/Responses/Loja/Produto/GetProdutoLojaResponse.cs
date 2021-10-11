using System.Collections.Generic;
using System.Threading.Tasks;

namespace relicarioApi.Domain.Commands.Responses.ProdutoLoja
{
    public class GetProdutoLojaResponse : ResponseBase
    {

        public GetProdutoLojaResponse(bool sucess, string erro) : base(sucess, erro)
        {
        }

        public GetProdutoLojaResponse()
        {

        }

        public GetProdutoLojaResponse(IEnumerable<Models.ProdutoLoja> produtos)
        {
            Produtos = produtos;
        }
        
        public IEnumerable<Models.ProdutoLoja> Produtos { get; set; }
    }
}
