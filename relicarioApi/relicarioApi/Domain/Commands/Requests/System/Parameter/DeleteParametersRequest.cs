using MediatR;
using relicarioApi.Domain.Commands.Responses.System.Parameter;
using System;

namespace relicarioApi.Domain.Commands.Requests.System.Parameter
{
    public class DeleteParametersRequest : IRequest<DeleteParametersResponse>
    {
        public Guid Id { get; set; }

    }
}
