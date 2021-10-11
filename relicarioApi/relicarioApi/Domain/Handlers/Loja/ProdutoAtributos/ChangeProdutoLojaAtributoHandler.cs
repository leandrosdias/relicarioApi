using AutoMapper;
using MediatR;
using relicarioApi.Data;
using relicarioApi.Domain.Commands.Requests.ProdutoLojaAtributo;
using relicarioApi.Domain.Commands.Responses.ProdutoLojaAtributo;
using relicarioApi.Repositories;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace relicarioApi.Domain.Handlers
{
    public class ChangeProdutoLojaAtributoHandler : IRequestHandler<ChangeProdutoLojaAtributoRequest, ChangeProdutoLojaAtributoResponse>
    {
        private readonly IProdutoLojaAtributoRepository _produtoLojaAtributoRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public ChangeProdutoLojaAtributoHandler(IProdutoLojaAtributoRepository produtoLojaAtributoRepository, IMapper mapper, IUnitOfWork uow)
        {
            _produtoLojaAtributoRepository = produtoLojaAtributoRepository;
            _mapper = mapper;
            _uow = uow;
        }

        public Task<ChangeProdutoLojaAtributoResponse> Handle(ChangeProdutoLojaAtributoRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var produtoLojaAtributo = _mapper.Map<Models.ProdutoLojaAtributo>(request);
                var result = _produtoLojaAtributoRepository.Update(produtoLojaAtributo);
                _uow.Commit();
                return Task.FromResult(_mapper.Map<ChangeProdutoLojaAtributoResponse>(result));
            }
            catch (Exception e)
            {
                _uow.Rollback();
                Debug.WriteLine("ChangeProdutoLojaAtributoResponse: " + e.Message + " Stack: " + e.StackTrace);
                return Task.FromResult(new ChangeProdutoLojaAtributoResponse(false, e.Message));
            }
        }
    }
}
