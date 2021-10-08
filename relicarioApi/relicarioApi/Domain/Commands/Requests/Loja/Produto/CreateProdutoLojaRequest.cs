using MediatR;
using relicarioApi.Domain.Commands.Responses;
using relicarioApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace relicarioApi.Domain.Commands.Requests
{
    public class CreateProdutoLojaRequest : IRequest<CreateProdutoLojaResponse>
    {
        [Required(ErrorMessage = "É necessário informar o código")]
        public int Codigo { get; set; }
        [Required(ErrorMessage = "É necessário informar o nome")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "É necessário informar uma descrição")]
        public string DescricaoCurta { get; set; }
        public string DescricaoLonga { get; set; }
        [Required(ErrorMessage = "É necessário informar o preço")]
        [Range(1, 99999, ErrorMessage = "O preço deve ser maior que 0")]
        public decimal PrecoOriginal { get; set; }
        public decimal PrecoPromocional { get; set; }
        public int Estoque { get; set; }
        public string Peso { get; set; }
        public decimal Comprimento { get; set; }
        public decimal Altura { get; set; }
        public decimal Largura { get; set; }
        public Guid CategoriaId { get; set; }
    }
}
