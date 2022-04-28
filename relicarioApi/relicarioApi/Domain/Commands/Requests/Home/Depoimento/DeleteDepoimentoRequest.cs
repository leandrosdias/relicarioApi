using MediatR;
using relicarioApi.Domain.Commands.Responses.Home.Depoimento;
using System;

namespace relicarioApi.Domain.Commands.Requests.Home.Depoimento
{
    public class DeleteDepoimentoRequest : IRequest<DeleteDepoimentoResponse>
    {
        public Guid Id { get; set; }
    }
}
