using MediatR;
using relicarioApi.Domain.Commands.Responses.System.Parameter;
using System;
using System.ComponentModel.DataAnnotations;

namespace relicarioApi.Domain.Commands.Requests.System.Parameter
{
    public class ChangeParametersRequest : IRequest<ChangeParametersResponse>
    {
        public Guid Id { get; set; }
        public string Param { get; set; }
        public string Value { get; set; }
    }
}
