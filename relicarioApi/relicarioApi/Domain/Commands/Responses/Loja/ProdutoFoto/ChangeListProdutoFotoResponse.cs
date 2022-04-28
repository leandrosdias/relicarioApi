using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace relicarioApi.Domain.Commands.Responses.Loja.ProdutoFoto
{
    public class ChangeListProdutoFotoResponse : ResponseBase
    {
        public ChangeListProdutoFotoResponse(bool sucess, string erro) : base(sucess, erro)
        {
        }

        public ChangeListProdutoFotoResponse()
        {
        }
    }
}
