using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using UsuariosApi.Data.Dto;
using UsuariosApi.Data.Requests;
using UsuariosApi.Models;

namespace UsuariosApi.Services
{
    public class CadastroService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUserCustom> _userManager;

        public CadastroService(IMapper mapper, UserManager<IdentityUserCustom> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public Result CadastraUsuatio(CreateUsuarioDto createDto)
        {
            if (string.IsNullOrWhiteSpace(createDto.UserName))
            {
                createDto.UserName = createDto.Email;
            }

            var usuario = _mapper.Map<Usuario>(createDto);
            var usuarioIdentity = _mapper.Map<IdentityUserCustom>(usuario);
            var resultadoIdentity = _userManager.CreateAsync(usuarioIdentity, createDto.Password);

            if (resultadoIdentity.Result.Succeeded)
            {
                var user = _userManager.FindByNameAsync(usuario.UserName).Result;
                return Result.Ok().WithSuccess(JsonSerializer.Serialize(user));
            }

            return Result.Fail("Falha ao cadastrar usuário");
        }

        public Result AtivaContaUsuario(AtivaContaRequest request)
        {
            var identityUser = _userManager.Users.FirstOrDefault(x => x.UserName == request.UserName);

            var identityResult = _userManager.ConfirmEmailAsync(identityUser, request.CodigoAtivacao).Result;

            if (identityResult.Succeeded)
            {
                return Result.Ok();
            }

            return Result.Fail("Falha ao ativar conta do usuário");
        }

        public async Task<Result> ChangeAdmUsersRequest(ChangeAdmUsersRequest request)
        {
            foreach (var username in request.Usernames)
            {
                var identityUser = await _userManager.FindByNameAsync(username);
                identityUser.Administrador = request.Administrador;
                var identityResult = await _userManager.UpdateAsync(identityUser);
                if (!identityResult.Succeeded)
                {
                    return Result.Fail("Erro ao alterar status de administrador do usuário: " + identityUser.UserName);
                }

            }

            return Result.Ok();
        }

        public async Task<Result> ChangeUsersRequest(ChangeUsersRequest request)
        {
            var identityUser = await _userManager.FindByNameAsync(request.UserName);

            if (identityUser == null)
            {
                return Result.Fail("Usuário não encontrado " + request.UserName);
            }

            identityUser.Ativo = request.Ativo;
            identityUser.Administrador = request.Administrador;
            identityUser.Email = request.Email;
            var identityResult = await _userManager.UpdateAsync(identityUser);
            if (!identityResult.Succeeded)
            {
                return Result.Fail("Erro ao atualizar usuário: " + identityUser.UserName);
            }

            return Result.Ok();
        }

        public async Task<Result> ChangeStatusUsers(ChangeStatusUsersRequest request)
        {
            foreach (var username in request.Usernames)
            {
                var identityUser = await _userManager.FindByNameAsync(username);
                identityUser.Ativo = request.Ativa;
                var identityResult = await _userManager.UpdateAsync(identityUser);
                if (!identityResult.Succeeded)
                {
                    return Result.Fail("Erro ao alterar status do usuário: " + identityUser.UserName);
                }

            }

            return Result.Ok();
        }
    }
}
