using MediatR;
using relicarioApi.Domain.Commands.Responses.ProdutoLojaRelacionado;
using System;
using System.ComponentModel.DataAnnotations;

namespace relicarioApi.Domain.Commands.Requests.ProdutoLojaRelacionado
{
    public class ChangeProdutoLojaRelacionadoRequest : IRequest<ChangeProdutoLojaRelacionadoResponse>
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "É necessário informar o id do produto principal")]
        public Guid ProdutoPrincipalId { get; set; }
        [Required(ErrorMessage = "É necessário informar o id do produto relacionado")]
        public Guid ProdutoRelacionadoId { get; set; }
    }
}
