using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace relicarioApi.Models
{
    [Table("USUARIO")]
    public class User : ModelBase
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string ConfirmationCode { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
        public virtual IEnumerable<UserAdress> Enderecos { get; set; }
        public virtual IEnumerable<CreditCard> Cards { get; set; }
    }
}
