using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace relicarioApi.Domain.Commands.Responses.Galeria.ProdutoFoto
{
    public class ChangeListProdutoGaleriaFotoResponse : ResponseBase
    {
        public ChangeListProdutoGaleriaFotoResponse(bool sucess, string erro) : base(sucess, erro)
        {
        }

        public ChangeListProdutoGaleriaFotoResponse()
        {
        }
    }
}
