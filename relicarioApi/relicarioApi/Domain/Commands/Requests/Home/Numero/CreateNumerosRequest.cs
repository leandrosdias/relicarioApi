using MediatR;
using relicarioApi.Domain.Commands.Responses.Home.Numeros;
using System.ComponentModel.DataAnnotations;

namespace relicarioApi.Domain.Commands.Requests.Home.Numeros
{
    public class CreateNumerosRequest : IRequest<CreateNumerosResponse>
    {
        [Required(ErrorMessage = "É necessário informar um numero")]
        public string Numero { get; set; }
        [Required(ErrorMessage = "É necessário informar uma descrição")]
        public string Descricao { get; set; }
       
    }
}
