using MediatR;
using relicarioApi.Domain.Commands.Responses.System.Parameter;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace relicarioApi.Domain.Commands.Requests.System.Parameter
{
    public class ChangeParametersRequest : IRequest<ChangeParametersResponse>
    {
        public Guid Id { get; set; }
        public string Param { get; set; }
        public string Value { get; set; }
        public string ContentString { get; set; }
        [JsonIgnore]
        public byte[] Content => string.IsNullOrWhiteSpace(ContentString) ? null : Convert.FromBase64String(ContentString.Split(',')[1]);
        public string Categoria { get; set; }
    }
}
