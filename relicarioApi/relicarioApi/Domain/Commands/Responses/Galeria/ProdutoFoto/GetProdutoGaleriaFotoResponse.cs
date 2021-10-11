using relicarioApi.Models;
using System.Collections.Generic;

namespace relicarioApi.Domain.Commands.Responses.Galeria.ProdutoFoto
{
    public class GetProdutoGaleriaFotoResponse : ResponseBase
    {
        public GetProdutoGaleriaFotoResponse(bool sucess, string erro) : base(sucess, erro)
        {
        }

        public GetProdutoGaleriaFotoResponse()
        {

        }

        public GetProdutoGaleriaFotoResponse(IEnumerable<ProdutoGaleriaFoto> fotos)
        {
            Fotos = fotos;
        }

        public IEnumerable<ProdutoGaleriaFoto> Fotos { get; set; }
    }
}
