using System;

namespace relicarioApi.Domain.Commands.Responses.Galeria.Artistas
{
    public class CreateArtistaResponse : ResponseBase
    {
        public CreateArtistaResponse(bool sucess, string erro) : base(sucess, erro)
        {
        }

        public CreateArtistaResponse()
        {

        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string DescricaoLonga { get; set; }
        public string DescricaoCurta { get; set; }
    }
}
