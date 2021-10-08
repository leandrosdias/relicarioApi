using MediatR;
using relicarioApi.Domain.Commands.Requests.CategoriaLoja;
using relicarioApi.Domain.Commands.Responses.CategoriaLoja;
using relicarioApi.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace relicarioApi.Domain.Handlers.CategoriaLoja
{
    public class GetCategoriaLojaHandler : IRequestHandler<GetCategoriaLojaRequest, GetCategoriaLojaResponse>
    {
        private readonly ICategoriaLojaRepository _categoriaLojaRepository;

        public GetCategoriaLojaHandler(ICategoriaLojaRepository categoriaLojaRepository)
        {
            _categoriaLojaRepository = categoriaLojaRepository;
        }

        public async Task<GetCategoriaLojaResponse> Handle(GetCategoriaLojaRequest request, CancellationToken cancellationToken)
        {
            try
            {
                return await Task.FromResult(new GetCategoriaLojaResponse(_categoriaLojaRepository.Get(request)));
            }
            catch (Exception e)
            {
                Debug.WriteLine($"{nameof(GetCategoriaLojaResponse)}  - {e.Message} Stack: {e.StackTrace} ");
                return await Task.FromResult(new GetCategoriaLojaResponse(false, e.Message));
            }
        }
    }
}
