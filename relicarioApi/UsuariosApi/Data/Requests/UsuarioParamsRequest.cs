using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsuariosApi.Data.Requests
{
    public class UsuarioParamsRequest
    {
        public string Usuario { get; set; }
        public bool? Ativo { get; set; }
        public bool? Administrador { get; set; }
    }
}
