using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace relicarioApi.Domain.Commands.Responses.Loja.ProdutoAtributos
{
    public class ChangeListProdutoAtributoResponse : ResponseBase
    {
        public ChangeListProdutoAtributoResponse(bool sucess, string erro) : base(sucess, erro)
        {
        }

        public ChangeListProdutoAtributoResponse()
        {
        }
    }
}
