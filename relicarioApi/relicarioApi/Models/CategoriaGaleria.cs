namespace relicarioApi.Models
{
    public class CategoriaGaleria : ModelBase
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public int CategoriaPai { get; set; }
    }
}
