using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UsuariosApi.Data.Dto;
using UsuariosApi.Data.Requests;
using UsuariosApi.Services;

namespace UsuariosApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CadastroController : ControllerBase
    {
        private readonly CadastroService _cadastroService;

        public CadastroController(CadastroService cadastroService)
        {
            _cadastroService = cadastroService;
        }

        [HttpPost]
        public IActionResult CadastraUsuario(CreateUsuarioDto createDto)
        {
            Result resultado = _cadastroService.CadastraUsuatio(createDto);
            if (resultado.IsFailed)
            {
                return StatusCode(500);
            }
            return Ok(resultado.Successes);
        }

        [HttpPost("/ativaTeste")]
        public IActionResult AtivaContaUsuario(AtivaContaRequest request)
        {
            Result result = _cadastroService.AtivaContaUsuario(request);

            if (result.IsFailed)
            {
                return StatusCode(500);
            }

            return Ok(result.Successes);
        }

        [HttpPost("/changeStatus")]
        public async Task<IActionResult> ChangeStatusUsuarios(ChangeStatusUsersRequest request)
        {
            Result result = await _cadastroService.ChangeStatusUsers(request);

            if (result.IsFailed)
            {
                return StatusCode(500);
            }

            return Ok();
        }

        [HttpPost("/changeAdm")]
        public async Task<IActionResult> ChangeAdmUsuarios(ChangeAdmUsersRequest request)
        {
            Result result = await _cadastroService.ChangeAdmUsersRequest(request);

            if (result.IsFailed)
            {
                return StatusCode(500);
            }

            return Ok();
        }

        [HttpPost("/changeUser")]
        public async Task<IActionResult> ChangeUser(ChangeUsersRequest request)
        {
            Result result = await _cadastroService.ChangeUsersRequest(request);

            if (result.IsFailed)
            {
                return StatusCode(500);
            }

            return Ok();
        }
    }
}
