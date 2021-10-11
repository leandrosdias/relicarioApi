using MediatR;
using relicarioApi.Domain.Commands.Responses.ProdutoLojaAtributo;
using System;
using System.ComponentModel.DataAnnotations;

namespace relicarioApi.Domain.Commands.Requests.ProdutoLojaAtributo
{
    public class CreateProdutoLojaAtributoRequest : IRequest<CreateProdutoLojaAtributoResponse>
    {
        [Required(ErrorMessage = "É necessário informar o nome")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "É necessário informar o valor")]
        public string Valor { get; set; }
        [Required(ErrorMessage = "É necessário informar o id do produto")]
        public Guid ProdutoLojaId { get; set; }
    }
}
