using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace relicarioApi.Models
{
    [Table("LOJA_PRODUTO_RELACIONADO")]
    public class ProdutoLojaRelacionado : ModelBase
    {
        public ProdutoLoja ProdutoPrincipal { get; set; }
        public Guid ProdutoPrincipalId { get; set; }
        public ProdutoLoja ProdutoRelacionado { get; set; }
        public Guid ProdutoRelacionadoId { get; set; }
    }
}
