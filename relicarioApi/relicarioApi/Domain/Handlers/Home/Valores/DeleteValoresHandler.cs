using MediatR;
using relicarioApi.Data;
using relicarioApi.Domain.Commands.Requests.Home.Valores;
using relicarioApi.Domain.Commands.Responses.Home.Valores;
using relicarioApi.Repositories.Home.Valores;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace relicarioApi.Domain.Handlers.Home.Valores
{
    public class DeleteValoresHandler : IRequestHandler<DeleteValoresRequest, DeleteValoresResponse>
    {
        private readonly IValoresRepository _valoresRepository;
        private readonly IUnitOfWork _uow;

        public DeleteValoresHandler(IValoresRepository valoresRepository, IUnitOfWork uow)
        {
            _valoresRepository = valoresRepository;
            _uow = uow;
        }

        public Task<DeleteValoresResponse> Handle(DeleteValoresRequest request, CancellationToken cancellationToken)
        {
            try
            {
                _valoresRepository.Delete(request);
                _uow.Commit();
                return Task.FromResult(new DeleteValoresResponse());
            }
            catch (Exception e)
            {
                Debug.WriteLine("DeleteValoresResponse: " + e.Message + " Stack: " + e.StackTrace);
                _uow.Rollback();
                return Task.FromResult(new DeleteValoresResponse(false, e.Message));
            }
        }
    }
}
