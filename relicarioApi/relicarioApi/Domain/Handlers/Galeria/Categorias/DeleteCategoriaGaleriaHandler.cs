using MediatR;
using relicarioApi.Data;
using relicarioApi.Domain.Commands.Requests.Galeria.Categorias;
using relicarioApi.Domain.Commands.Responses.Galeria.Categorias;
using relicarioApi.Repositories.Galeria.Categorias;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace relicarioApi.Domain.Handlers.Galeria.Categorias
{
    public class DeleteCategoriaGaleriaHandler : IRequestHandler<DeleteCategoriaGaleriaRequest, DeleteCategoriaGaleriaResponse>
    {
        private readonly ICategoriaGaleriaRepository _categoriaGaleriaRepository;
        private readonly IUnitOfWork _uow;

        public DeleteCategoriaGaleriaHandler(ICategoriaGaleriaRepository categoriaGaleriaRepository, IUnitOfWork uow)
        {
            _categoriaGaleriaRepository = categoriaGaleriaRepository;
            _uow = uow;
        }

        public Task<DeleteCategoriaGaleriaResponse> Handle(DeleteCategoriaGaleriaRequest request, CancellationToken cancellationToken)
        {
            try
            {
                _categoriaGaleriaRepository.Delete(request);
                _uow.Commit();
                return Task.FromResult(new DeleteCategoriaGaleriaResponse());
            }
            catch (Exception e)
            {
                Debug.WriteLine("DeleteCategoriaGaleriaResponse: " + e.Message + " Stack: " + e.StackTrace);
                _uow.Rollback();
                return Task.FromResult(new DeleteCategoriaGaleriaResponse(false, e.Message));
            }
        }
    }
}
