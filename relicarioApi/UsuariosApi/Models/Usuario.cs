namespace UsuariosApi.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool Ativo { get; set; }
        public bool Administrador { get; set; }
    }
}
