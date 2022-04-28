using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace relicarioApi.Models
{
    [Table("LOJA_PRODUTO_RELACIONADO")]
    public class ProdutoLojaRelacionado : ModelBase
    {
        [JsonIgnore]
        public virtual ProdutoLoja ProdutoPrincipal { get; set; }
        public Guid ProdutoPrincipalId { get; set; }
        [JsonIgnore]
        public virtual ProdutoLoja ProdutoRelacionado { get; set; }
        public Guid ProdutoRelacionadoId { get; set; }
        public string ProdutoRelacionadoNome { get; set; }
    }
}
