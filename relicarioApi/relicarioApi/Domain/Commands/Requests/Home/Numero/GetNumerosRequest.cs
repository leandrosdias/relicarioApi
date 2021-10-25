using MediatR;
using relicarioApi.Domain.Commands.Responses.Home.Numeros;
using System;

namespace relicarioApi.Domain.Commands.Requests.Home.Numeros
{
    public class GetNumerosRequest : IRequest<GetNumerosResponse>
    {
        public Guid Id { get; set; }

    }
}
