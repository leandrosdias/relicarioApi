using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UsuariosApi.Data.Requests
{
    public class ChangeAdmUsersRequest
    {
        [Required(ErrorMessage = "Necessário informar os nomes!")]
        public List<string> Usernames { get; set; }
        [Required(ErrorMessage = "Necessário informar o administrador!")]
        public bool Administrador { get; set; }
    }
}
