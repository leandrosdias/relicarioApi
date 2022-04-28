using MediatR;
using relicarioApi.Data;
using relicarioApi.Domain.Commands.Requests.Home.Depoimento;
using relicarioApi.Domain.Commands.Responses.Home.Depoimento;
using relicarioApi.Repositories.Home.Depoimento;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace relicarioApi.Domain.Handlers.Home.Depoimento
{
    public class DeleteDepoimentoHandler : IRequestHandler<DeleteDepoimentoRequest, DeleteDepoimentoResponse>
    {
        private readonly IDepoimentoRepository _depoimentoRepository;
        private readonly IUnitOfWork _uow;

        public DeleteDepoimentoHandler(IDepoimentoRepository depoimentoRepository, IUnitOfWork uow)
        {
            _depoimentoRepository = depoimentoRepository;
            _uow = uow;
        }

        public Task<DeleteDepoimentoResponse> Handle(DeleteDepoimentoRequest request, CancellationToken cancellationToken)
        {
            try
            {
                _depoimentoRepository.Delete(request);
                _uow.Commit();
                return Task.FromResult(new DeleteDepoimentoResponse());
            }
            catch (Exception e)
            {
                Debug.WriteLine("DeleteDepoimentoResponse: " + e.Message + " Stack: " + e.StackTrace);
                _uow.Rollback();
                return Task.FromResult(new DeleteDepoimentoResponse(false, e.Message));
            }
        }
    }
}
