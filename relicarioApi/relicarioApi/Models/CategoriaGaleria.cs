using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace relicarioApi.Models
{
    [Table("GALERIA_CATEGORIA")]
    public class CategoriaGaleria : ModelBase
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public int CategoriaPai { get; set; }
        [JsonIgnore]
        public virtual List<ProdutoGaleria> Produtos { get; set; }
    }
}
