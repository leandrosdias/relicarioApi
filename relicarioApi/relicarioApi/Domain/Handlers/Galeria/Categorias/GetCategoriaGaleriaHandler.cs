using MediatR;
using relicarioApi.Domain.Commands.Requests.Galeria.Categorias;
using relicarioApi.Domain.Commands.Responses.Galeria.Categorias;
using relicarioApi.Repositories.Galeria.Categorias;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace relicarioApi.Domain.Handlers.Galeria.Categorias
{
    public class GetCategoriaGaleriaHandler : IRequestHandler<GetCategoriaGaleriaRequest, GetCategoriaGaleriaResponse>
    {
        private readonly ICategoriaGaleriaRepository _categoriaGaleriaRepository;

        public GetCategoriaGaleriaHandler(ICategoriaGaleriaRepository categoriaGaleriaRepository)
        {
            _categoriaGaleriaRepository = categoriaGaleriaRepository;
        }

        public async Task<GetCategoriaGaleriaResponse> Handle(GetCategoriaGaleriaRequest request, CancellationToken cancellationToken)
        {
            try
            {
                return await Task.FromResult(new GetCategoriaGaleriaResponse(_categoriaGaleriaRepository.Get(request)));
            }
            catch (Exception e)
            {
                Debug.WriteLine("GetCategoriaGaleriaResponse: " + e.Message + " Stack: " + e.StackTrace);
                return await Task.FromResult(new GetCategoriaGaleriaResponse(false, e.Message));
            }
        }
    }
}
