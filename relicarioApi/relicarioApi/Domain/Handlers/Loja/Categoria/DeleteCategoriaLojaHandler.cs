using MediatR;
using relicarioApi.Data;
using relicarioApi.Domain.Commands.Requests.CategoriaLoja;
using relicarioApi.Domain.Commands.Responses.CategoriaLoja;
using relicarioApi.Repositories;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace relicarioApi.Domain.Handlers.CategoriaLoja
{
    public class DeleteCategoriaLojaHandler : IRequestHandler<DeleteCategoriaLojaRequest, DeleteCategoriaLojaResponse>
    {
        private readonly ICategoriaLojaRepository _categoriaLojaRepository;
        private readonly IUnitOfWork _uow;

        public DeleteCategoriaLojaHandler(ICategoriaLojaRepository categoriaLojaRepository, IUnitOfWork uow)
        {
            _categoriaLojaRepository = categoriaLojaRepository;
            _uow = uow;
        }

        public Task<DeleteCategoriaLojaResponse> Handle(DeleteCategoriaLojaRequest request, CancellationToken cancellationToken)
        {
            try
            {
                _categoriaLojaRepository.Delete(request);
                _uow.Commit();
                return Task.FromResult(new DeleteCategoriaLojaResponse());
            }
            catch (Exception e)
            {
                Debug.WriteLine($"{nameof(DeleteCategoriaLojaResponse)}  - {e.Message} Stack: {e.StackTrace} ");
                _uow.Rollback();
                return Task.FromResult(new DeleteCategoriaLojaResponse(false, e.Message));
            }
        }
    }
}
