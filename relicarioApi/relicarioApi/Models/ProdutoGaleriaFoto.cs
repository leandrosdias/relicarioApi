using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace relicarioApi.Models
{
    [Table("GALERIA_PRODUTO_FOTO")]
    public class ProdutoGaleriaFoto : ModelBase
    {
        public int Sequencia { get; set; }
        public byte[] Foto { get; set; }
        public Guid ProdutoGaleriaId { get; set; }
    }
}
