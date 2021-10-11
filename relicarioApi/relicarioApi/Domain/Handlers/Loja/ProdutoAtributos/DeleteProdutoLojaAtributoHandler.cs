using MediatR;
using relicarioApi.Data;
using relicarioApi.Domain.Commands.Requests.ProdutoLojaAtributo;
using relicarioApi.Domain.Commands.Responses.ProdutoLojaAtributo;
using relicarioApi.Repositories;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace relicarioApi.Domain.Handlers.ProdutoLojaAtributo
{
    public class DeleteProdutoLojaAtributoHandler : IRequestHandler<DeleteProdutoLojaAtributoRequest, DeleteProdutoLojaAtributoResponse>
    {
        private readonly IProdutoLojaAtributoRepository _produtoLojaAtributoRepository;
        private readonly IUnitOfWork _uow;

        public DeleteProdutoLojaAtributoHandler(IProdutoLojaAtributoRepository produtoLojaAtributoRepository, IUnitOfWork uow)
        {
            _produtoLojaAtributoRepository = produtoLojaAtributoRepository;
            _uow = uow;
        }

        public Task<DeleteProdutoLojaAtributoResponse> Handle(DeleteProdutoLojaAtributoRequest request, CancellationToken cancellationToken)
        {
            try
            {
                _produtoLojaAtributoRepository.Delete(request);
                _uow.Commit();
                return Task.FromResult(new DeleteProdutoLojaAtributoResponse());
            }
            catch (Exception e)
            {
                Debug.WriteLine($"{nameof(DeleteProdutoLojaAtributoResponse)}  - {e.Message} Stack: {e.StackTrace} ");
                _uow.Rollback();
                return Task.FromResult(new DeleteProdutoLojaAtributoResponse(false, e.Message));
            }
        }
    }
}
