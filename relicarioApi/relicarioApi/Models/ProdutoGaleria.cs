using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace relicarioApi.Models
{
    [Table("GALERIA_PRODUTO")]
    public class ProdutoGaleria : ModelBase
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string DescricaoCurta { get; set; }
        public string DescricaoLonga { get; set; }
        public virtual Artista Artista { get; set; }
        public Guid ArtistaId { get; set; }
        public virtual CategoriaGaleria CategoriaGaleria { get; set; }
        public Guid CategoriaGaleriaId { get; set; }
        public virtual IEnumerable<ProdutoGaleriaFoto> Fotos { get; set; }
        public Nullable<Guid> ProdutoLojaId { get; set; }
    }
}
