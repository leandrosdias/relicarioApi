using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UsuariosApi.Data.Requests
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "Necessário informar o email!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Necessário informar a senha!")]
        public string Password { get; set; }
    }
}
