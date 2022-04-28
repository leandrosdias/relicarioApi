using MediatR;
using relicarioApi.Domain.Commands.Responses.Galeria.Artistas;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace relicarioApi.Domain.Commands.Requests.Galeria.Artistas
{
    public class ChangeArtistaRequest : IRequest<ChangeArtistaResponse>
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "É necessário informar o nome do artista")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "É necessário informar uma descrição para o artista")]
        public string DescricaoLonga { get; set; }
        public string DescricaoCurta { get; set; }
        public string FotoBase64 { get; set; }
        [JsonIgnore]
        public byte[] Foto => string.IsNullOrWhiteSpace(FotoBase64) ? null : Convert.FromBase64String(FotoBase64.Split(',')[1]);
    }
}
