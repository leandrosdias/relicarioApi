using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace relicarioApi.Domain.Commands.Responses.Home.Valores
{
    public class ChangeValoresResponse : ResponseBase
    {
        public ChangeValoresResponse(bool sucess, string erro) : base(sucess, erro)
        {
        }

        public ChangeValoresResponse()
        {

        }

        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Icone { get; set; }
    }
}
