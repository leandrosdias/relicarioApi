using MediatR;
using relicarioApi.Domain.Commands.Responses.ProdutoLoja;
using System;
using System.ComponentModel.DataAnnotations;

namespace relicarioApi.Domain.Commands.Requests.ProdutoLoja
{
    public class ChangeProdutoLojaRequest : IRequest<ChangeProdutoLojaResponse>
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "É necessário informar o código da categoria")]
        public string Codigo { get; set; }
        [Required(ErrorMessage = "É necessário informar o nome da categoria")]
        public string Nome { get; set; }
        public string DescricaoCurta { get; set; }
        public string DescricaoLonga { get; set; }
        [Required(ErrorMessage = "É necessário informar o preço")]
        public decimal PrecoOriginal { get; set; }
        public decimal PrecoPromocional { get; set; }
        public int Estoque { get; set; }
        public string Peso { get; set; }
        public decimal Comprimento { get; set; }
        public decimal Altura { get; set; }
        public decimal Largura { get; set; }
        public Guid CategoriaLojaId { get; set; }

    }
}
