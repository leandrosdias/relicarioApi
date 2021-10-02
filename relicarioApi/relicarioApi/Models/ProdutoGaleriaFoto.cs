using System;

namespace relicarioApi.Models
{
    public class ProdutoGaleriaFoto
    {
        public int Sequencia { get; set; }
        public Array[] Foto { get; set; }
        public Guid ProdutoGategoriaId { get; set; }
    }
}
