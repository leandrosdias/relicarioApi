using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UsuariosApi.Models;

namespace UsuariosApi.Services
{
    public class TokenService
    {
        public Token CreateToken(IdentityUserCustom usuario)
        {
            Claim[] direitosUsuario = new Claim[]
            {
                new Claim("email", usuario.Email),
                new Claim("id", usuario.Id.ToString())
            };

            var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("65a48315-81b8-48d2-95f3-8069cf7be50e"));

            var credentials = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(claims: direitosUsuario, signingCredentials: credentials, expires: System.DateTime.UtcNow.AddDays(1));

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return new Token(tokenString);
        }
    }
}
