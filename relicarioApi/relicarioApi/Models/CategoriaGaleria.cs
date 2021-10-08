using System.ComponentModel.DataAnnotations.Schema;

namespace relicarioApi.Models
{
    [Table("GALERIA_CATEGORIA")]
    public class CategoriaGaleria : ModelBase
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public int CategoriaPai { get; set; }
    }
}
