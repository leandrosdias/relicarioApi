using MediatR;
using relicarioApi.Data;
using relicarioApi.Domain.Commands.Requests.Loja.ProdutoFoto;
using relicarioApi.Domain.Commands.Responses.Loja.ProdutoFoto;
using relicarioApi.Repositories.Loja.Produtos;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace relicarioApi.Domain.Handlers.Loja.ProdutoFoto
{
    public class DeleteProdutoLojaFotoHandler : IRequestHandler<DeleteProdutoLojaFotoRequest, DeleteProdutoLojaFotoResponse>
    {
        private readonly IProdutoLojaFotoRepository _produtoLojaFotoRepository;
        private readonly IUnitOfWork _uow;

        public DeleteProdutoLojaFotoHandler(IProdutoLojaFotoRepository produtoLojaFotoRepository, IUnitOfWork uow)
        {
            _produtoLojaFotoRepository = produtoLojaFotoRepository;
            _uow = uow;
        }

        public Task<DeleteProdutoLojaFotoResponse> Handle(DeleteProdutoLojaFotoRequest request, CancellationToken cancellationToken)
        {
            try
            {
                _produtoLojaFotoRepository.Delete(request);
                _uow.Commit();
                return Task.FromResult(new DeleteProdutoLojaFotoResponse());
            }
            catch (Exception e)
            {
                Debug.WriteLine("DeleteProdutoLojaFotoResponse: " + e.Message + " Stack: " + e.StackTrace);
                _uow.Rollback();
                return Task.FromResult(new DeleteProdutoLojaFotoResponse(false, e.Message));
            }
        }
    }
}
