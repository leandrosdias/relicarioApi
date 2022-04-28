using MediatR;
using relicarioApi.Domain.Commands.Requests.Galeria.ProdutoFoto;
using relicarioApi.Domain.Commands.Responses.Galeria.Produtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace relicarioApi.Domain.Commands.Requests.Galeria.Produtos
{
    public class ChangeGaleriaProdutoRequest : IRequest<ChangeGaleriaProdutoResponse>
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "É necessário informar o código para o produto")]
        public string Codigo { get; set; }
        [Required(ErrorMessage = "É necessário informar o nome para o produto")]
        public string Nome { get; set; }
        public string DescricaoCurta { get; set; }
        public string DescricaoLonga { get; set; }
        [Required(ErrorMessage = "É necessário informar o artista do produto")]
        public Guid ArtistaId { get; set; }
        [Required(ErrorMessage = "É necessário informar a categoria para o produto")]
        public Guid CategoriaGaleriaId { get; set; }
        public IEnumerable<CreateProdutoGaleriaFotoRequest> Fotos { get; set; }
        public Guid ProdutoLojaId { get; set; }
        public string ProdutoLojaNome { get; set; }
    }
}
