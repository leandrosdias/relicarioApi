using MediatR;
using relicarioApi.Domain.Commands.Responses.Loja.ProdutoFoto;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace relicarioApi.Domain.Commands.Requests.Loja.ProdutoFoto
{
    public class ChangeProdutoLojaFotoRequest : IRequest<ChangeProdutoLojaFotoResponse>
    {
        public Guid Id { get; set; }
        public int Sequencia { get; set; }
        public string FotoBase64 { get; set; }
        [JsonIgnore]
        public byte[] Foto => Convert.FromBase64String(FotoBase64);
        [Required(ErrorMessage = "É necessário informar o id do produto")]
        public Guid ProdutoLojaId { get; set; }
    }
}
