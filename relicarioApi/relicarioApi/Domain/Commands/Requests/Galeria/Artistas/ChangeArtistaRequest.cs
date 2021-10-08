using MediatR;
using relicarioApi.Domain.Commands.Responses.Galeria.Artistas;
using System;
using System.ComponentModel.DataAnnotations;

namespace relicarioApi.Domain.Commands.Requests.Galeria.Artistas
{
    public class ChangeArtistaRequest : IRequest<ChangeArtistaResponse>
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "É necessário informar o nome do artista")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Números e caracteres especiais não são permitidos no nome.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "É necessário informar uma descrição para o artista")]
        public string DescricaoLonga { get; set; }
        public string DescricaoCurta { get; set; }

    }
}
