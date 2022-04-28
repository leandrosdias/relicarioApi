using Microsoft.AspNetCore.Identity;

namespace UsuariosApi.Models
{
    public class IdentityUserCustom : IdentityUser<int>
    {
        public bool Ativo { get; set; }
        public bool Administrador { get; set; }
    }
}
