using relicarioApi.Models;
using System.Collections.Generic;

namespace relicarioApi.Domain.Commands.Responses.Home.Numeros
{
    public class GetNumerosResponse : ResponseBase
    {
        public GetNumerosResponse(bool sucess, string erro) : base(sucess, erro)
        {
        }

        public GetNumerosResponse()
        {

        }

        public GetNumerosResponse(IEnumerable<Models.Numeros> numeros)
        {
            Numeros = numeros;
        }

        public IEnumerable<Models.Numeros> Numeros { get; set; }
    }
}
