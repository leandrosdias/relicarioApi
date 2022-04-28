using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using UsuariosApi.Data.Requests;
using UsuariosApi.Models;

namespace UsuariosApi.Services
{
    public class LoginService
    {
        private readonly SignInManager<IdentityUserCustom> _signInManager;
        private readonly UserManager<IdentityUserCustom> _userManager;
        private readonly TokenService _tokenService;

        public LoginService(SignInManager<IdentityUserCustom> signInManager, UserManager<IdentityUserCustom> userManager, TokenService tokenService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _tokenService = tokenService;
        }

        public Result LogaUsuario(LoginRequest request)
        {
            var user = _userManager.FindByEmailAsync(request.Email).Result;

            if (user == null)
            {
                return Result.Fail("Usuário ou senha incorretos!");
            }

            var resultIdentity = _signInManager.PasswordSignInAsync(user.UserName, request.Password, false, false);

            if (resultIdentity.Result.Succeeded)
            {
                var userIdentity = _signInManager.UserManager.Users.FirstOrDefault(x => x.NormalizedEmail == request.Email.ToUpper());
                if (userIdentity == null)
                {
                    return Result.Fail("Ocorreu um erro para recuperar o usuário!");
                }

                var token = _tokenService.CreateToken(userIdentity);
                return Result.Ok().WithSuccess(token.Valor);
            }

            return Result.Fail("Usuário ou senha incorretos!");
        }

        public Result Logout()
        {
            var result = _signInManager.SignOutAsync();
            if (result.IsCompletedSuccessfully)
            {
                return Result.Ok();
            }

            return Result.Fail("Logout falhou!");
        }
    }
}
