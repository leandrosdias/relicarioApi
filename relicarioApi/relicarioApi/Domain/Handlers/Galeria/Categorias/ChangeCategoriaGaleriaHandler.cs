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
using relicarioApi.Models;

namespace relicarioApi.Domain.Handlers.Galeria.Categorias
{
    public class ChangeCategoriaGaleriaHandler : IRequestHandler<ChangeCategoriaGaleriaRequest, ChangeCategoriaGaleriaResponse>
    {
        private readonly ICategoriaGaleriaRepository _categoriaGaleriaRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public ChangeCategoriaGaleriaHandler(ICategoriaGaleriaRepository CategoriaGaleriaRepository, IMapper mapper, IUnitOfWork uow)
        {
            _categoriaGaleriaRepository = CategoriaGaleriaRepository;
            _mapper = mapper;
            _uow = uow;
        }

        public Task<ChangeCategoriaGaleriaResponse> Handle(ChangeCategoriaGaleriaRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var categoriaGaleria = _mapper.Map<CategoriaGaleria>(request);

                if (_categoriaGaleriaRepository.FindByNome(categoriaGaleria.Nome)?.Id != request.Id)
                {
                    return Task.FromResult(new ChangeCategoriaGaleriaResponse(false, $"Já existe categoria cadastrado com o nome: {categoriaGaleria.Nome}"));
                }

                if (_categoriaGaleriaRepository.FindByCodigo(categoriaGaleria.Codigo)?.Id != request.Id)
                {
                    return Task.FromResult(new ChangeCategoriaGaleriaResponse(false, $"Já existe categoria cadastrado com o código: {categoriaGaleria.Codigo}"));
                }

                if (request.Codigo == 0)
                {
                    return Task.FromResult(new ChangeCategoriaGaleriaResponse(false, $"O código da categoria não pode ser nulo"));
                }


                var result = _categoriaGaleriaRepository.Update(categoriaGaleria);
                _uow.Commit();
                return Task.FromResult(_mapper.Map<ChangeCategoriaGaleriaResponse>(result));
            }
            catch (Exception e)
            {
                _uow.Rollback();
                Debug.WriteLine("ChangeCategoriaGaleriaHandler: " + e.Message + " Stack: " + e.StackTrace);
                return Task.FromResult(new ChangeCategoriaGaleriaResponse(false, e.Message));
            }
        }
    }
}
