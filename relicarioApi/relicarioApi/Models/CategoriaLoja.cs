using System.ComponentModel.DataAnnotations.Schema;

namespace relicarioApi.Models
{
    [Table("LOJA_CATEGORIA")]
    public class CategoriaLoja : ModelBase
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public int CodigoPai { get; set; }
        public bool BarraSuperior { get; set; }
    }
}
