using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UsuariosApi.Data.Requests
{
    public class ChangeUsersRequest
    {
        [Required(ErrorMessage = "Necessário informar o nome!")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Necessário informar o email!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Necessário informar status!")]
        public bool Ativo { get; set; }
        [Required(ErrorMessage = "Necessário informar administrador!")]
        public bool Administrador { get; set; }
    }
}
