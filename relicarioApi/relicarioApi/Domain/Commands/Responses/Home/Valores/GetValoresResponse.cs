using relicarioApi.Models;
using System.Collections.Generic;

namespace relicarioApi.Domain.Commands.Responses.Home.Valores
{
    public class GetValoresResponse : ResponseBase
    {
        public GetValoresResponse(bool sucess, string erro) : base(sucess, erro)
        {
        }

        public GetValoresResponse()
        {

        }

        public GetValoresResponse(IEnumerable<Models.Valores> valores)
        {
            Valores = valores;
        }

        public IEnumerable<Models.Valores> Valores { get; set; }
    }
}
