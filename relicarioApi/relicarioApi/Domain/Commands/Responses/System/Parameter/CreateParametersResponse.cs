using System;

namespace relicarioApi.Domain.Commands.Responses.System.Parameter
{
    public class CreateParametersResponse : ResponseBase
    {
        public CreateParametersResponse(bool sucess, string erro) : base(sucess, erro)
        {
        }

        public CreateParametersResponse()
        {

        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string DescricaoLonga { get; set; }
        public string DescricaoCurta { get; set; }
    }
}
