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

        public string Nome { get; set; }
        public string DescricaoLonga { get; set; }
        public string DescricaoCurta { get; set; }
    }
}
