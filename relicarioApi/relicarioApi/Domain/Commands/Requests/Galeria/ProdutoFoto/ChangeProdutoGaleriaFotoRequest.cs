using MediatR;
using relicarioApi.Domain.Commands.Responses.Galeria.ProdutoFoto;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace relicarioApi.Domain.Commands.Requests.Galeria.ProdutoFoto
{
    public class ChangeProdutoGaleriaFotoRequest : IRequest<ChangeProdutoGaleriaFotoResponse>
    {
        public Guid Id { get; set; }
        public int Sequencia { get; set; }
        public string FotoBase64 { get; set; }
        [JsonIgnore]
        public byte[] Foto => Convert.FromBase64String(FotoBase64);
        [Required(ErrorMessage = "É necessário informar o id do produto")]
        public Guid ProdutoGaleriaId { get; set; }
    }
}
