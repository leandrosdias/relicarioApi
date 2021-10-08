using AutoMapper;
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
    public class CreateArtistaHandler : IRequestHandler<CreateArtistaRequest, CreateArtistaResponse>
    {
        private readonly IArtistaRepository _artistaRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public CreateArtistaHandler(IArtistaRepository ArtistaRepository, IMapper mapper, IUnitOfWork uow)
        {
            _artistaRepository = ArtistaRepository;
            _mapper = mapper;
            _uow = uow;
        }

        public Task<CreateArtistaResponse> Handle(CreateArtistaRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var artista = _mapper.Map<Models.Artista>(request);

                if (_artistaRepository.FindByNome(artista.Nome) != null)
                {
                    return Task.FromResult(new CreateArtistaResponse(false, $"Já existe artista cadastrado com o nome: {artista.Nome}"));
                }

                _artistaRepository.Save(artista);
                _uow.Commit();
                return Task.FromResult(_mapper.Map<CreateArtistaResponse>(artista));
            }
            catch (Exception e)
            {
                _uow.Rollback();
                Debug.WriteLine("CreateArtistaResponse: " + e.Message + " Stack: " + e.StackTrace);
                return Task.FromResult(new CreateArtistaResponse(false, e.Message));
            }
        }
    }
}
