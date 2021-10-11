using MediatR;
using relicarioApi.Data;
using relicarioApi.Domain.Commands.Requests.Galeria.ProdutoFoto;
using relicarioApi.Domain.Commands.Responses.Galeria.ProdutoFoto;
using relicarioApi.Repositories.Galeria.Produtos;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace relicarioApi.Domain.Handlers.Galeria.ProdutoFoto
{
    public class DeleteProdutoGaleriaFotoHandler : IRequestHandler<DeleteProdutoGaleriaFotoRequest, DeleteProdutoGaleriaFotoResponse>
    {
        private readonly IProdutoGaleriaFotoRepository _produtoGaleriaFotoRepository;
        private readonly IUnitOfWork _uow;

        public DeleteProdutoGaleriaFotoHandler(IProdutoGaleriaFotoRepository produtoGaleriaFotoRepository, IUnitOfWork uow)
        {
            _produtoGaleriaFotoRepository = produtoGaleriaFotoRepository;
            _uow = uow;
        }

        public Task<DeleteProdutoGaleriaFotoResponse> Handle(DeleteProdutoGaleriaFotoRequest request, CancellationToken cancellationToken)
        {
            try
            {
                _produtoGaleriaFotoRepository.Delete(request);
                _uow.Commit();
                return Task.FromResult(new DeleteProdutoGaleriaFotoResponse());
            }
            catch (Exception e)
            {
                Debug.WriteLine("DeleteProdutoGaleriaFotoResponse: " + e.Message + " Stack: " + e.StackTrace);
                _uow.Rollback();
                return Task.FromResult(new DeleteProdutoGaleriaFotoResponse(false, e.Message));
            }
        }
    }
}
