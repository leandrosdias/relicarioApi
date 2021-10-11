using System.Collections.Generic;
using System.Threading.Tasks;

namespace relicarioApi.Domain.Commands.Responses.ProdutoLojaRelacionado
{
    public class GetProdutoLojaRelacionadoResponse : ResponseBase
    {

        public GetProdutoLojaRelacionadoResponse(bool sucess, string erro) : base(sucess, erro)
        {
        }

        public GetProdutoLojaRelacionadoResponse()
        {

        }

        public GetProdutoLojaRelacionadoResponse(IEnumerable<Models.ProdutoLojaRelacionado> produtos)
        {
            Produtos = produtos;
        }
        
        public IEnumerable<Models.ProdutoLojaRelacionado> Produtos { get; set; }
    }
}
