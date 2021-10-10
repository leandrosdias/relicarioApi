using AutoMapper;
using MediatR;
using relicarioApi.Data;
using relicarioApi.Domain.Commands.Requests.Galeria.Artistas;
using relicarioApi.Domain.Commands.Responses.Galeria.Artistas;
using relicarioApi.Repositories.Galeria.Artistas;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using relicarioApi.Models;

namespace relicarioApi.Domain.Handlers.Galeria.Artistas
{
    public class ChangeArtistaHandler : IRequestHandler<ChangeArtistaRequest, ChangeArtistaResponse>
    {
        private readonly IArtistaRepository _artistaRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public ChangeArtistaHandler(IArtistaRepository ArtistaRepository, IMapper mapper, IUnitOfWork uow)
        {
            _artistaRepository = ArtistaRepository;
            _mapper = mapper;
            _uow = uow;
        }

        public Task<ChangeArtistaResponse> Handle(ChangeArtistaRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var artista = _mapper.Map<Artista>(request);
                var result = _artistaRepository.Update(artista);
                _uow.Commit();
                return Task.FromResult(_mapper.Map<ChangeArtistaResponse>(result));
            }
            catch (Exception e)
            {
                _uow.Rollback();
                Debug.WriteLine("ChangeArtistaHandler: " + e.Message + " Stack: " + e.StackTrace);
                return Task.FromResult(new ChangeArtistaResponse(false, e.Message));
            }
        }
    }
}

