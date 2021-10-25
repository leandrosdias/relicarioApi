using MediatR;
using relicarioApi.Data;
using relicarioApi.Domain.Commands.Requests.Home.Numeros;
using relicarioApi.Domain.Commands.Responses.Home.Numeros;
using relicarioApi.Repositories.Home.Numeros;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace relicarioApi.Domain.Handlers.Home.Numeros
{
    public class DeleteNumerosHandler : IRequestHandler<DeleteNumerosRequest, DeleteNumerosResponse>
    {
        private readonly INumerosRepository _numerosRepository;
        private readonly IUnitOfWork _uow;

        public DeleteNumerosHandler(INumerosRepository numerosRepository, IUnitOfWork uow)
        {
            _numerosRepository = numerosRepository;
            _uow = uow;
        }

        public Task<DeleteNumerosResponse> Handle(DeleteNumerosRequest request, CancellationToken cancellationToken)
        {
            try
            {
                _numerosRepository.Delete(request);
                _uow.Commit();
                return Task.FromResult(new DeleteNumerosResponse());
            }
            catch (Exception e)
            {
                Debug.WriteLine("DeleteNumerosResponse: " + e.Message + " Stack: " + e.StackTrace);
                _uow.Rollback();
                return Task.FromResult(new DeleteNumerosResponse(false, e.Message));
            }
        }
    }
}
