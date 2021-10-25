using AutoMapper;
using MediatR;
using relicarioApi.Data;
using relicarioApi.Domain.Commands.Requests.Galeria.Categorias;
using relicarioApi.Domain.Commands.Responses.Galeria.Categorias;
using relicarioApi.Repositories.Galeria.Categorias;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace relicarioApi.Domain.Handlers.Galeria.Categorias
{
    public class CreateCategoriaGaleriaHandler : IRequestHandler<CreateCategoriaGaleriaRequest, CreateCategoriaGaleriaResponse>
    {
        private readonly ICategoriaGaleriaRepository _categoriaGaleriaRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public CreateCategoriaGaleriaHandler(ICategoriaGaleriaRepository categoriaGaleriaRepository, IMapper mapper, IUnitOfWork uow)
        {
            _categoriaGaleriaRepository = categoriaGaleriaRepository;
            _mapper = mapper;
            _uow = uow;
        }

        public Task<CreateCategoriaGaleriaResponse> Handle(CreateCategoriaGaleriaRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var categoriaGaleria = _mapper.Map<Models.CategoriaGaleria>(request);

                if (_categoriaGaleriaRepository.FindByNome(categoriaGaleria.Nome) != null)
                {
                    return Task.FromResult(new CreateCategoriaGaleriaResponse(false, $"Já existe categoria cadastrado com o nome: {categoriaGaleria.Nome}"));
                }

                if (_categoriaGaleriaRepository.FindByCodigo(categoriaGaleria.Codigo) != null)
                {
                    return Task.FromResult(new CreateCategoriaGaleriaResponse(false, $"Já existe categoria cadastrado com o código: {categoriaGaleria.Codigo}"));
                }

                if (string.IsNullOrWhiteSpace(request.Codigo))
                {
                    return Task.FromResult(new CreateCategoriaGaleriaResponse(false, $"O código da categoria não pode ser nulo"));
                }

                _categoriaGaleriaRepository.Save(categoriaGaleria);
                _uow.Commit();
                return Task.FromResult(_mapper.Map<CreateCategoriaGaleriaResponse>(categoriaGaleria));
            }
            catch (Exception e)
            {
                _uow.Rollback();
                Debug.WriteLine("CreateCategoriaGaleriaResponse: " + e.Message + " Stack: " + e.StackTrace);
                return Task.FromResult(new CreateCategoriaGaleriaResponse(false, e.Message));
            }
        }
    }
}
