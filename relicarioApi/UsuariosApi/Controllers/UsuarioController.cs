using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Data.Requests;
using UsuariosApi.Services;

namespace UsuariosApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;

        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public IActionResult GetUsuarios([FromQuery] UsuarioParamsRequest request)
        {
            var result = _usuarioService.GetUsers(request);
            if (result.IsFailed)
            {
                return StatusCode(500);
            }
            return Ok(result.Successes);
        }
    }
}
