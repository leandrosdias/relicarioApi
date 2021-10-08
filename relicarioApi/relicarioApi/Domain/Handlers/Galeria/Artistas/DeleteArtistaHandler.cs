using MediatR;
using relicarioApi.Data;
using relicarioApi.Domain.Commands.Requests.Galeria.Artistas;
using relicarioApi.Domain.Commands.Responses.Galeria.Artistas;
using relicarioApi.Repositories.Galeria.Artistas;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace relicarioApi.Domain.Handlers.Galeria.Artistas
{
    public class DeleteArtistaHandler : IRequestHandler<DeleteArtistaRequest, DeleteArtistaResponse>
    {
        private readonly IArtistaRepository _artistaRepository;
        private readonly IUnitOfWork _uow;

        public DeleteArtistaHandler(IArtistaRepository artistaRepository, IUnitOfWork uow)
        {
            _artistaRepository = artistaRepository;
            _uow = uow;
        }

        public Task<DeleteArtistaResponse> Handle(DeleteArtistaRequest request, CancellationToken cancellationToken)
        {
            try
            {
                _artistaRepository.Delete(request);
                _uow.Commit();
                return Task.FromResult(new DeleteArtistaResponse());
            }
            catch (Exception e)
            {
                Debug.WriteLine("DeleteArtistaResponse: " + e.Message + " Stack: " + e.StackTrace);
                _uow.Rollback();
                return Task.FromResult(new DeleteArtistaResponse(false, e.Message));
            }
        }
    }
}
