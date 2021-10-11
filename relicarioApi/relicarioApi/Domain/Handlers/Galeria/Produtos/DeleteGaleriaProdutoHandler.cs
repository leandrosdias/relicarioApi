using MediatR;
using relicarioApi.Data;
using relicarioApi.Domain.Commands.Requests.Galeria.Produtos;
using relicarioApi.Domain.Commands.Responses.Galeria.Produtos;
using relicarioApi.Repositories.Galeria.Produtos;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace relicarioApi.Domain.Handlers.Galeria.Produtos
{
    public class DeleteGaleriaProdutoHandler : IRequestHandler<DeleteGaleriaProdutoRequest, DeleteGaleriaProdutoResponse>
    {
        private readonly IGaleriaProdutoRepository _galeriaProdutoRepository;
        private readonly IUnitOfWork _uow;

        public DeleteGaleriaProdutoHandler(IGaleriaProdutoRepository galeriaProdutoRepository, IUnitOfWork uow)
        {
            _galeriaProdutoRepository = galeriaProdutoRepository;
            _uow = uow;
        }

        public Task<DeleteGaleriaProdutoResponse> Handle(DeleteGaleriaProdutoRequest request, CancellationToken cancellationToken)
        {
            try
            {
                _galeriaProdutoRepository.Delete(request);
                _uow.Commit();
                return Task.FromResult(new DeleteGaleriaProdutoResponse());
            }
            catch (Exception e)
            {
                Debug.WriteLine("DeleteGaleriaProdutoResponse: " + e.Message + " Stack: " + e.StackTrace);
                _uow.Rollback();
                return Task.FromResult(new DeleteGaleriaProdutoResponse(false, e.Message));
            }
        }
    }
}
