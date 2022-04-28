using MediatR;
using relicarioApi.Domain.Commands.Responses.Loja.ProdutoFoto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace relicarioApi.Domain.Commands.Requests.Loja.ProdutoFoto
{
    public class CreateProdutoLojaFotoRequest : IRequest<CreateProdutoLojaFotoResponse>
    {
        public int Sequencia { get; set; }
        public string FotoBase64 { get; set; }
        [JsonIgnore]
        public byte[] Foto => Convert.FromBase64String(FotoBase64.Split(',')[1]);
        [Required(ErrorMessage = "É necessário informar o id do produto")]
        public Guid ProdutoLojaId { get; set; }
    }
}
