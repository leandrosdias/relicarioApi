using System.Collections.Generic;
using System.Threading.Tasks;

namespace relicarioApi.Domain.Commands.Responses.ProdutoLojaAtributo
{
    public class GetProdutoLojaAtributoResponse : ResponseBase
    {

        public GetProdutoLojaAtributoResponse(bool sucess, string erro) : base(sucess, erro)
        {
        }

        public GetProdutoLojaAtributoResponse()
        {

        }

        public GetProdutoLojaAtributoResponse(IEnumerable<Models.ProdutoLojaAtributo> produtos)
        {
            Produtos = produtos;
        }
        
        public IEnumerable<Models.ProdutoLojaAtributo> Produtos { get; set; }
    }
}
