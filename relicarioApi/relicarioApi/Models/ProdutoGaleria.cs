using System;
using System.Collections.Generic;

namespace relicarioApi.Models
{
    public class ProdutoGaleria : ModelBase
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string DescricaoCurta { get; set; }
        public string DescricaoLonga { get; set; }
        public Artista Artista { get; set; }
        public Guid ArtistaId { get; set; }
        public CategoriaGaleria CategoriaGaleria { get; set; }
        public Guid CategoriaGaleriaId { get; set; }
        public IEnumerable<ProdutoGaleriaFoto> Fotos { get; set; }
    }
}
