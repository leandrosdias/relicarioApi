using MediatR;
using relicarioApi.Domain.Commands.Responses.Home.Valores;
using System;

namespace relicarioApi.Domain.Commands.Requests.Home.Valores
{
    public class GetValoresRequest : IRequest<GetValoresResponse>
    {
        public Guid Id { get; set; }

    }
}
