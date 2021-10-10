using System;

namespace relicarioApi.Domain.Commands.Responses.Galeria.Categorias
{
    public class CreateCategoriaGaleriaResponse : ResponseBase
    {
        public CreateCategoriaGaleriaResponse(bool sucess, string erro) : base(sucess, erro)
        {
        }

        public CreateCategoriaGaleriaResponse()
        {

        }

        public Guid Id { get; set; }
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public int CategoriaPai { get; set; }
    }
}
