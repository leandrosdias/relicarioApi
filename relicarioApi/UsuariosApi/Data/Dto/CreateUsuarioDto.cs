using System.ComponentModel.DataAnnotations;

namespace UsuariosApi.Data.Dto
{
    public class CreateUsuarioDto
    {
        [Required(ErrorMessage = "Necessário informar o nome!")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Necessário informar o email!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Necessário informar a senha!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Necessário informar repetir senha!")]
        [Compare("Password", ErrorMessage = "Senhas não são compativeis!")]
        public string RePassord { get; set; }
        [Required(ErrorMessage = "Necessário informar status!")]
        public bool Ativo { get; set; }
        [Required(ErrorMessage = "Necessário informar administrador!")]
        public bool Administrador { get; set; }
    }
}
