using MediatR;
using relicarioApi.Data;
using relicarioApi.Domain.Commands.Requests.ProdutoLojaRelacionado;
using relicarioApi.Domain.Commands.Responses.ProdutoLojaRelacionado;
using relicarioApi.Repositories;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace relicarioApi.Domain.Handlers.ProdutoLojaRelacionado
{
    public class DeleteProdutoLojaRelacionadoHandler : IRequestHandler<DeleteProdutoLojaRelacionadoRequest, DeleteProdutoLojaRelacionadoResponse>
    {
        private readonly IProdutoLojaRelacionadoRepository _produtoLojaRelacionadoRepository;
        private readonly IUnitOfWork _uow;

        public DeleteProdutoLojaRelacionadoHandler(IProdutoLojaRelacionadoRepository produtoLojaRelacionadoRepository, IUnitOfWork uow)
        {
            _produtoLojaRelacionadoRepository = produtoLojaRelacionadoRepository;
            _uow = uow;
        }

        public Task<DeleteProdutoLojaRelacionadoResponse> Handle(DeleteProdutoLojaRelacionadoRequest request, CancellationToken cancellationToken)
        {
            try
            {
                _produtoLojaRelacionadoRepository.Delete(request);
                _uow.Commit();
                return Task.FromResult(new DeleteProdutoLojaRelacionadoResponse());
            }
            catch (Exception e)
            {
                Debug.WriteLine($"{nameof(DeleteProdutoLojaRelacionadoResponse)}  - {e.Message} Stack: {e.StackTrace} ");
                _uow.Rollback();
                return Task.FromResult(new DeleteProdutoLojaRelacionadoResponse(false, e.Message));
            }
        }
    }
}
