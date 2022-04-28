using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsuariosApi.Data.Requests;
using UsuariosApi.Services;

namespace UsuariosApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly LoginService _loginService;

        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public IActionResult LogaUsuario(LoginRequest request)
        {
            var result = _loginService.LogaUsuario(request);
            if (result.IsFailed)
            {
                return Unauthorized();
            }

            return Ok(result.Successes);
        }

        [HttpPost("/logout")]
        public IActionResult LogoutUsuario()
        {
            var result = _loginService.Logout();
            if (result.IsFailed)
            {
                return Unauthorized();
            }

            return Ok(result.Successes);
        }
    }
}
