using AutoMapper;
using MediatR;
using relicarioApi.Data;
using relicarioApi.Domain.Commands.Requests.ProdutoLoja;
using relicarioApi.Domain.Commands.Responses.ProdutoLoja;
using relicarioApi.Repositories;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace relicarioApi.Domain.Handlers
{
    public class ChangeProdutoLojaHandler : IRequestHandler<ChangeProdutoLojaRequest, ChangeProdutoLojaResponse>
    {
        private readonly IProdutoLojaRepository _produtoLojaRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public ChangeProdutoLojaHandler(IProdutoLojaRepository produtoLojaRepository, IMapper mapper, IUnitOfWork uow)
        {
            _produtoLojaRepository = produtoLojaRepository;
            _mapper = mapper;
            _uow = uow;
        }

        public Task<ChangeProdutoLojaResponse> Handle(ChangeProdutoLojaRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var produtoLoja = _mapper.Map<Models.ProdutoLoja>(request);
                var result = _produtoLojaRepository.Update(produtoLoja);
                _uow.Commit();
                return Task.FromResult(_mapper.Map<ChangeProdutoLojaResponse>(result));
            }
            catch (Exception e)
            {
                _uow.Rollback();
                Debug.WriteLine("ChangeProdutoLojaResponse: " + e.Message + " Stack: " + e.StackTrace);
                return Task.FromResult(new ChangeProdutoLojaResponse(false, e.Message));
            }
        }
    }
}
