using relicarioApi.Models;
using System.Collections.Generic;

namespace relicarioApi.Domain.Commands.Responses.Loja.ProdutoFoto
{
    public class GetProdutoLojaFotoResponse : ResponseBase
    {
        public GetProdutoLojaFotoResponse(bool sucess, string erro) : base(sucess, erro)
        {
        }

        public GetProdutoLojaFotoResponse()
        {

        }

        public GetProdutoLojaFotoResponse(IEnumerable<ProdutoLojaFoto> fotos)
        {
            Fotos = fotos;
        }

        public IEnumerable<ProdutoLojaFoto> Fotos { get; set; }
    }
}
