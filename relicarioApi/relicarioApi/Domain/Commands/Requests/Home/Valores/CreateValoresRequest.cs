using MediatR;
using relicarioApi.Domain.Commands.Responses.Home.Valores;
using System.ComponentModel.DataAnnotations;

namespace relicarioApi.Domain.Commands.Requests.Home.Valores
{
    public class CreateValoresRequest : IRequest<CreateValoresResponse>
    {
        [Required(ErrorMessage = "É necessário informar um título")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "É necessário informar uma descrição")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "É necessário informar um ícone")]
        public string Icone { get; set; }

    }
}
