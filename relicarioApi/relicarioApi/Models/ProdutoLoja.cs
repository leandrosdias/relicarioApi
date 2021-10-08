using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace relicarioApi.Models
{
    [Table("LOJA_PRODUTO")]
    public class ProdutoLoja : ModelBase
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string DescricaoCurta { get; set; }
        public string DescricaoLonga { get; set; }
        public decimal PrecoOriginal { get; set; }
        public decimal PrecoPromocional { get; set; }
        public int Estoque { get; set; }
        public string Peso { get; set; }
        public decimal Comprimento { get; set; }
        public decimal Altura { get; set; }
        public decimal Largura { get; set; }
        public virtual CategoriaLoja CategoriaLoja { get; set; }
        public Guid CategoriaLojaId { get; set; }
        public virtual List<ProdutoLojaAtributo> ProdutoLojaAtributos { get; set; }
        public virtual List<ProdutoLojaRelacionado> ProdutosRelacionados { get; set; }
        public virtual List<ProdutoLojaFoto> Fotos { get; set; }
    }
}
