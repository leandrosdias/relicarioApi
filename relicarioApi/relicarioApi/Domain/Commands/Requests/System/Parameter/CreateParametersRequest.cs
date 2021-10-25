using MediatR;
using relicarioApi.Domain.Commands.Responses.System.Parameter;
using System.ComponentModel.DataAnnotations;

namespace relicarioApi.Domain.Commands.Requests.System.Parameter
{
    public class CreateParametersRequest : IRequest<CreateParametersResponse>
    {
        [Required(ErrorMessage = "É necessário informar o nome do parâmetro")]
        public string Param { get; set; }
        [Required(ErrorMessage = "É necessário informar o valor do parâmetro")]
        public string Value { get; set; }

    }
}
