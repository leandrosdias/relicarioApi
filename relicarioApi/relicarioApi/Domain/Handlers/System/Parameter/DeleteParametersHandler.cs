using MediatR;
using relicarioApi.Data;
using relicarioApi.Domain.Commands.Requests.System.Parameter;
using relicarioApi.Domain.Commands.Responses.System.Parameter;
using relicarioApi.Repositories.System.Parameter;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace relicarioApi.Domain.Handlers.System.Parameter
{
    public class DeleteParametersHandler : IRequestHandler<DeleteParametersRequest, DeleteParametersResponse>
    {
        private readonly IParametersRepository _parametersRepository;
        private readonly IUnitOfWork _uow;

        public DeleteParametersHandler(IParametersRepository ParametersRepository, IUnitOfWork uow)
        {
            _parametersRepository = ParametersRepository;
            _uow = uow;
        }

        public Task<DeleteParametersResponse> Handle(DeleteParametersRequest request, CancellationToken cancellationToken)
        {
            try
            {
                _parametersRepository.Delete(request);
                _uow.Commit();
                return Task.FromResult(new DeleteParametersResponse());
            }
            catch (Exception e)
            {
                Debug.WriteLine("DeleteParametersResponse: " + e.Message + " Stack: " + e.StackTrace);
                _uow.Rollback();
                return Task.FromResult(new DeleteParametersResponse(false, e.Message));
            }
        }
    }
}
