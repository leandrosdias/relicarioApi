using System;

namespace relicarioApi.Domain.Commands.Responses.Home.Numeros
{
    public class CreateNumerosResponse : ResponseBase
    {
        public CreateNumerosResponse(bool sucess, string erro) : base(sucess, erro)
        {
        }

        public CreateNumerosResponse()
        {

        }

        public Guid Id { get; set; }
        public int Numero { get; set; }
        public string Descricao { get; set; }
    }
}
