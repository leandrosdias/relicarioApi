using MediatR;
using relicarioApi.Domain.Commands.Responses.Home.Valores;
using System;

namespace relicarioApi.Domain.Commands.Requests.Home.Valores
{
    public class DeleteValoresRequest : IRequest<DeleteValoresResponse>
    {
        public Guid Id { get; set; }

    }
}
