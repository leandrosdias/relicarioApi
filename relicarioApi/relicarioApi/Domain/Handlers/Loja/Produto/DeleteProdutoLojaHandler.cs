using MediatR;
using relicarioApi.Data;
using relicarioApi.Domain.Commands.Requests.ProdutoLoja;
using relicarioApi.Domain.Commands.Responses.ProdutoLoja;
using relicarioApi.Repositories;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace relicarioApi.Domain.Handlers.ProdutoLoja
{
    public class DeleteProdutoLojaHandler : IRequestHandler<DeleteProdutoLojaRequest, DeleteProdutoLojaResponse>
    {
        private readonly IProdutoLojaRepository _produtoLojaRepository;
        private readonly IUnitOfWork _uow;

        public DeleteProdutoLojaHandler(IProdutoLojaRepository produtoLojaRepository, IUnitOfWork uow)
        {
            _produtoLojaRepository = produtoLojaRepository;
            _uow = uow;
        }

        public Task<DeleteProdutoLojaResponse> Handle(DeleteProdutoLojaRequest request, CancellationToken cancellationToken)
        {
            try
            {
                _produtoLojaRepository.Delete(request);
                _uow.Commit();
                return Task.FromResult(new DeleteProdutoLojaResponse());
            }
            catch (Exception e)
            {
                Debug.WriteLine($"{nameof(DeleteProdutoLojaResponse)}  - {e.Message} Stack: {e.StackTrace} ");
                _uow.Rollback();
                return Task.FromResult(new DeleteProdutoLojaResponse(false, e.Message));
            }
        }
    }
}
