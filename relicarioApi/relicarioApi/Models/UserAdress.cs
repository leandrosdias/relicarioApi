using System.ComponentModel.DataAnnotations.Schema;

namespace relicarioApi.Models
{
    [Table("USUARIO_ENDERECO")]
    public class UserAdress : ModelBase
    {
        public int Sequencia { get; set; }
        public bool Default { get; set; }
        public string Cep { get; set; }
        public string NomeDestinatario { get; set; }
        public int Numero { get; set; }
        public string Endereco { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Estado { get; set; }
        public string Telefone { get; set; }
    }
}
