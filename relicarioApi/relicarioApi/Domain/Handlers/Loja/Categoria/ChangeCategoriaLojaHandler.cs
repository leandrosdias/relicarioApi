using AutoMapper;
using MediatR;
using relicarioApi.Data;
using relicarioApi.Domain.Commands.Requests.CategoriaLoja;
using relicarioApi.Domain.Commands.Responses.CategoriaLoja;
using relicarioApi.Repositories;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace relicarioApi.Domain.Handlers
{
    public class ChangeCategoriaLojaHandler : IRequestHandler<ChangeCategoriaLojaRequest, ChangeCategoriaLojaResponse>
    {
        private readonly ICategoriaLojaRepository _categoriaLojaRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public ChangeCategoriaLojaHandler(ICategoriaLojaRepository categoriaLojaRepository, IMapper mapper, IUnitOfWork uow)
        {
            _categoriaLojaRepository = categoriaLojaRepository;
            _mapper = mapper;
            _uow = uow;
        }

        public Task<ChangeCategoriaLojaResponse> Handle(ChangeCategoriaLojaRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var categoriaLoja = _mapper.Map<Models.CategoriaLoja>(request);
                var result = _categoriaLojaRepository.Update(categoriaLoja);
                _uow.Commit();
                return Task.FromResult(_mapper.Map<ChangeCategoriaLojaResponse>(result));
            }
            catch (Exception e)
            {
                _uow.Rollback();
                Debug.WriteLine("ChangeCategoriaLojaResponse: " + e.Message + " Stack: " + e.StackTrace);
                return Task.FromResult(new ChangeCategoriaLojaResponse(false, e.Message));
            }
        }
    }
}
