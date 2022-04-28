using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace relicarioApi.Models
{
    [Table("DEPOIMENTO")]
    public class Depoimento : ModelBase
    {
        public int Sequencia { get; set; }
        public byte[] Foto { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}
