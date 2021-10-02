using System;

namespace relicarioApi.Models
{
    public class ProdutoLojaFoto
    {
        public int Sequencia { get; set; }
        public Array[] Foto { get; set; }
        public Guid ProdutoLojaId { get; set; }

    }
}
