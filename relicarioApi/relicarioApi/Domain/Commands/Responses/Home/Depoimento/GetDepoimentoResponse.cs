using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace relicarioApi.Domain.Commands.Responses.Home.Depoimento
{
    public class GetDepoimentoResponse : ResponseBase
    {
        public GetDepoimentoResponse(bool sucess, string erro) : base(sucess, erro)
        {
        }

        public GetDepoimentoResponse()
        {

        }

        public GetDepoimentoResponse(IEnumerable<Models.Depoimento> depoimentos)
        {
            Depoimentos = depoimentos;
        }

        public IEnumerable<Models.Depoimento> Depoimentos { get; set; }
    }
}
