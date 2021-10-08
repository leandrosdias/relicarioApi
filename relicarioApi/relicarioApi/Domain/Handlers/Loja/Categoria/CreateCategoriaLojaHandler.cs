using AutoMapper;
using MediatR;
using relicarioApi.Data;
using relicarioApi.Domain.Commands.Requests.CategoriaLoja;
using relicarioApi.Domain.Commands.Responses.CategoriaLoja;
using relicarioApi.Repositories;
using System.Threading;
using System.Threading.Tasks;
using relicarioApi.Models;
using System;
using System.Diagnostics;

namespace relicarioApi.Domain.Handlers
{
    public class CreateCategoriaLojaHandler : IRequestHandler<CreateCategoriaLojaRequest, CreateCategoriaLojaResponse>
    {
        private readonly ICategoriaLojaRepository _categoriaLojaRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public CreateCategoriaLojaHandler(ICategoriaLojaRepository categoriaLojaRepository, IMapper mapper, IUnitOfWork uow)
        {
            _categoriaLojaRepository = categoriaLojaRepository;
            _mapper = mapper;
            _uow = uow;
        }

        public Task<CreateCategoriaLojaResponse> Handle(CreateCategoriaLojaRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var categoriaLoja = _mapper.Map<Models.CategoriaLoja>(request);

                if (_categoriaLojaRepository.FindByCodigo(categoriaLoja.Codigo) != null)
                {
                    return Task.FromResult(new CreateCategoriaLojaResponse(false, $"Já existe categoria cadastrada com o código: {categoriaLoja.Codigo}"));
                }

                _categoriaLojaRepository.Save(categoriaLoja);
                _uow.Commit();
                return Task.FromResult(_mapper.Map<CreateCategoriaLojaResponse>(categoriaLoja));
            }
            catch (Exception e)
            {
                _uow.Rollback();
                Debug.WriteLine("CreateCategoriaLojaHandler: " + e.Message + " Stack: " + e.StackTrace);
                return Task.FromResult(new CreateCategoriaLojaResponse(false, e.Message));
            }
        }
    }
}
