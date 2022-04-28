using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UsuariosApi.Data.Requests
{
    public class AtivaContaRequest
    {
        [Required(ErrorMessage = "Necessário informar o nome!")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Necessário informar o Codigo de Ativacao!")]
        public string CodigoAtivacao { get; set; }
    }
}
