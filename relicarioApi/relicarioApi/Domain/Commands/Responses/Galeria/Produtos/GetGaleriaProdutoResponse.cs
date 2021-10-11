using relicarioApi.Models;
using System.Collections.Generic;

namespace relicarioApi.Domain.Commands.Responses.Galeria.Produtos
{
    public class GetGaleriaProdutoResponse : ResponseBase
    {
        public GetGaleriaProdutoResponse(bool sucess, string erro) : base(sucess, erro)
        {
        }

        public GetGaleriaProdutoResponse()
        {

        }

        public GetGaleriaProdutoResponse(IEnumerable<ProdutoGaleria> produtos)
        {
            Produtos = produtos;
        }

        public IEnumerable<ProdutoGaleria> Produtos { get; set; }
    }
}
