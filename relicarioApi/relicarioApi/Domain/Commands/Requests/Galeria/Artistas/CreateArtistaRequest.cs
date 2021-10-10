using MediatR;
using relicarioApi.Domain.Commands.Responses.Galeria.Artistas;
using System.ComponentModel.DataAnnotations;

namespace relicarioApi.Domain.Commands.Requests.Galeria.Artistas
{
    public class CreateArtistaRequest : IRequest<CreateArtistaResponse>
    {
        [Required(ErrorMessage = "É necessário informar o nome do artista")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "É necessário informar uma descrição para o artista")]
        public string DescricaoLonga { get; set; }
        public string DescricaoCurta { get; set; }

    }
}
