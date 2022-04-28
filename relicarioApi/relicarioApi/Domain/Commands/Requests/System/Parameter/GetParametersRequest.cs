using MediatR;
using relicarioApi.Domain.Commands.Responses.System.Parameter;
using System;

namespace relicarioApi.Domain.Commands.Requests.System.Parameter
{
    public class GetParametersRequest : IRequest<GetParametersResponse>
    {
        public Guid Id { get; set; }
        public string Param { get; set; }
        public string Categoria { get; set; }
    }
}
