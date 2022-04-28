using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using UsuariosApi.Data.Requests;
using UsuariosApi.Models;

namespace UsuariosApi.Services
{
    public class UsuarioService
    {
        private readonly UserManager<IdentityUserCustom> _userManager;
        private readonly IMapper _mapper;

        public UsuarioService(IMapper mapper, SignInManager<IdentityUserCustom> signInManager, UserManager<IdentityUserCustom> userManager)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public Result GetUsers(UsuarioParamsRequest request)
        {
            var users = _userManager.Users;

            if (!string.IsNullOrWhiteSpace(request.Usuario))
            {
                users = users.Where(user => user.UserName.ToUpper().Contains(request.Usuario));
            }

            if (request.Ativo != null)
            {
                users = users.Where(x => x.Ativo == request.Ativo);
            }

            if (request.Administrador != null)
            {
                users = users.Where(x => x.Administrador == request.Administrador);
            }

            var userList = users.ToList();
            if (users == null || userList.Count <= 0)
            {
                return Result.Fail("Nenhum usuário encontrado para a pesquisa!");
            }

            var result = new List<Usuario>();
            foreach (var user in userList)
            {
                result.Add(_mapper.Map<Usuario>(user));
            }

            return Result.Ok().WithSuccess(JsonSerializer.Serialize(result));
        }
    }
}
