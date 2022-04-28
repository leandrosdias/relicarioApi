using MediatR;
using relicarioApi.Domain.Commands.Requests.Loja.ProdutoFoto;
using relicarioApi.Domain.Commands.Responses.ProdutoLoja;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace relicarioApi.Domain.Commands.Requests.ProdutoLoja
{
    public class CreateProdutoLojaRequest : IRequest<CreateProdutoLojaResponse>
    {
        [Required(ErrorMessage = "É necessário informar o código do produto")]
        public string Codigo { get; set; }
        [Required(ErrorMessage = "É necessário informar o nome do produto")]
        public string Nome { get; set; }
        public string DescricaoCurta { get; set; }
        public string DescricaoLonga { get; set; }
        [Required(ErrorMessage = "É necessário informar o preço")]
        public decimal PrecoOriginal { get; set; }
        public decimal PrecoPromocional { get; set; }
        public int Estoque { get; set; }
        public decimal Peso { get; set; }
        public decimal Comprimento { get; set; }
        public decimal Altura { get; set; }
        public decimal Largura { get; set; }
        public bool Status { get; set; }
        public Guid CategoriaLojaId { get; set; }
        public List<CreateProdutoLojaFotoRequest> Fotos { get; set; }
    }
}
