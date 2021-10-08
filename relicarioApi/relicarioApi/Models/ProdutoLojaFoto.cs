using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace relicarioApi.Models
{
    [Table("LOJA_PRODUTO_FOTO")]
    public class ProdutoLojaFoto : ModelBase
    {
        public int Sequencia { get; set; }
        public byte[] Foto { get; set; }
        public Guid ProdutoLojaId { get; set; }

    }
}
