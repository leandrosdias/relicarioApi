using MediatR;
using relicarioApi.Domain.Commands.Responses.Home.Depoimento;
using System;
using System.Text.Json.Serialization;

namespace relicarioApi.Domain.Commands.Requests.Home.Depoimento
{
    public class ChangeDepoimentoRequest : IRequest<ChangeDepoimentoResponse>
    {
        public Guid Id { get; set; }
        public int Sequencia { get; set; }
        public string FotoBase64 { get; set; }
        [JsonIgnore]
        public byte[] Foto => Convert.FromBase64String(FotoBase64.Split(',')[1]);
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}
