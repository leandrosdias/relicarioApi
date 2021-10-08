using System;

namespace relicarioApi.Domain.Commands.Responses.CategoriaLoja
{
    public class CreateCategoriaLojaResponse : ResponseBase
    {
        public CreateCategoriaLojaResponse(bool sucess, string erro) : base(sucess, erro)
        {
        }

        public CreateCategoriaLojaResponse()
        {

        }

        public Guid Id { get; set; }
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public int CodigoPai { get; set; }
        public bool BarraSuperior { get; set; }
    }
}
