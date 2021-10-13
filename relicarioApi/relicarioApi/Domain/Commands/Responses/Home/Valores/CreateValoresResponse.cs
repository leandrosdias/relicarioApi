using System;

namespace relicarioApi.Domain.Commands.Responses.Home.Valores
{
    public class CreateValoresResponse : ResponseBase
    {
        public CreateValoresResponse(bool sucess, string erro) : base(sucess, erro)
        {
        }

        public CreateValoresResponse()
        {

        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string DescricaoLonga { get; set; }
        public string DescricaoCurta { get; set; }
    }
}
