using MediatR;
using relicarioApi.Domain.Commands.Requests.Galeria.Artistas;
using relicarioApi.Domain.Commands.Responses.Galeria.Artistas;
using relicarioApi.Repositories.Galeria.Artistas;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace relicarioApi.Domain.Handlers.Galeria.Artistas
{
    public class GetArtistaHandler : IRequestHandler<GetArtistaRequest, GetArtistaResponse>
    {
        private readonly IArtistaRepository _artistaRepository;

        public GetArtistaHandler(IArtistaRepository artistaRepository)
        {
            _artistaRepository = artistaRepository;
        }

        public async Task<GetArtistaResponse> Handle(GetArtistaRequest request, CancellationToken cancellationToken)
        {
            try
            {
                return await Task.FromResult(new GetArtistaResponse(_artistaRepository.Get(request)));
            }
            catch (Exception e)
            {
                Debug.WriteLine("GetArtistaResponse: " + e.Message + " Stack: " + e.StackTrace);
                return await Task.FromResult(new GetArtistaResponse(false, e.Message));
            }
        }
    }
}
