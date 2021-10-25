using relicarioApi.Models;
using System.Collections.Generic;

namespace relicarioApi.Domain.Commands.Responses.System.Parameter
{
    public class GetParametersResponse : ResponseBase
    {
        public GetParametersResponse(bool sucess, string erro) : base(sucess, erro)
        {
        }

        public GetParametersResponse()
        {

        }

        public GetParametersResponse(IEnumerable<Models.Parameters> parameters)
        {
            Parameters = parameters;
        }

        public IEnumerable<Models.Parameters> Parameters { get; set; }
    }
}
