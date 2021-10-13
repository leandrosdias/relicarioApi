using MediatR;
using relicarioApi.Domain.Commands.Responses.Home.Valores;
using System;
using System.ComponentModel.DataAnnotations;

namespace relicarioApi.Domain.Commands.Requests.Home.Valores
{
    public class ChangeValoresRequest : IRequest<ChangeValoresResponse>
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Icone { get; set; }

    }
}
