using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsuariosApi.Models
{
    public class Token
    {
        public Token(string valor)
        {
            Valor = valor;
        }

        public string Valor { get; }
    }
}
