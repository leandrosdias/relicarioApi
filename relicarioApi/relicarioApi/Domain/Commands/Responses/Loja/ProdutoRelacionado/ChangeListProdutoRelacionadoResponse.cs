using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace relicarioApi.Domain.Commands.Responses.Loja.ProdutoRelacionado
{
    public class ChangeListProdutoRelacionadoResponse : ResponseBase
    {
        public ChangeListProdutoRelacionadoResponse(bool sucess, string erro) : base(sucess, erro)
        {
        }

        public ChangeListProdutoRelacionadoResponse()
        {
        }
    }
}
