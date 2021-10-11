using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace relicarioApi.Models
{
    public class Artista : ModelBase
    {
        public string Nome { get; set; }
        public string DescricaoLonga { get; set; }
        public string DescricaoCurta { get; set; }
        [JsonIgnore]
        public virtual List<ProdutoGaleria> Produtos { get; set; }
    }
}
