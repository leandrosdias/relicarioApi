using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace relicarioApi.Domain.Commands.Responses.Home.Depoimento
{
    public class DeleteDepoimentoResponse : ResponseBase
    {
        public DeleteDepoimentoResponse(bool sucess, string erro) : base(sucess, erro)
        {
        }

        public DeleteDepoimentoResponse()
        {


        }
    }
}
