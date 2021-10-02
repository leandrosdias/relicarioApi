using System;

namespace relicarioApi.Models
{
    public class ProdutoLojaAtributo : ModelBase
    {
        public string Nome { get; set; }
        public string Valor { get; set; }
        public virtual ProdutoLoja ProdutoLoja { get; set; }
        public  Guid ProdutoLojaId { get; set; }

        //estabelecer no builder builder.Entity<ProdutoLojaAtributo>().HasOne(produtoLojaAtributo => produtoLojaAtributo.ProdutoLoja).WithMany(produtoLoja => produtoLoja.ProdutoLojaAtributos).HasForeignKey(produtoLojaAtributo => produtoLojaAtributo.ProdutoLojaId)
    }
}
