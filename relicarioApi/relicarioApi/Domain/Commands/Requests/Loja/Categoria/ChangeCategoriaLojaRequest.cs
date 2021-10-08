using MediatR;
using relicarioApi.Domain.Commands.Responses.CategoriaLoja;
using System;
using System.ComponentModel.DataAnnotations;

namespace relicarioApi.Domain.Commands.Requests.CategoriaLoja
{
    public class ChangeCategoriaLojaRequest : IRequest<ChangeCategoriaLojaResponse>
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "É necessário informar o código da categoria")]
        public int Codigo { get; set; }
        [Required(ErrorMessage = "É necessário informar o nome da categoria")]
        public string Nome { get; set; }
        public int CodigoPai { get; set; }
        public bool BarraSuperior { get; set; }

    }
}
