using MediatR;
using relicarioApi.Domain.Commands.Responses.Galeria.Categorias;
using System;
using System.ComponentModel.DataAnnotations;

namespace relicarioApi.Domain.Commands.Requests.Galeria.Categorias
{
    public class ChangeCategoriaGaleriaRequest : IRequest<ChangeCategoriaGaleriaResponse>
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "É necessário informar um código para a categoria")]
        public int Codigo { get; set; }
        [Required(ErrorMessage = "É necessário informar um nome para a categoria")]
        public string Nome { get; set; }
        public int CategoriaPai { get; set; }
    }
}
