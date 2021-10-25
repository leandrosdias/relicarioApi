using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace relicarioApi.Domain.Commands.Responses.System.Parameter
{
    public class ChangeParametersResponse : ResponseBase
    {
        public ChangeParametersResponse(bool sucess, string erro) : base(sucess, erro)
        {
        }

        public ChangeParametersResponse()
        {

        }

        public string Nome { get; set; }
        public string DescricaoLonga { get; set; }
        public string DescricaoCurta { get; set; }
    }
}
