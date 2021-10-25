using AutoMapper;
using MediatR;
using relicarioApi.Data;
using relicarioApi.Domain.Commands.Requests.System.Parameter;
using relicarioApi.Domain.Commands.Responses.System.Parameter;
using relicarioApi.Repositories.System.Parameter;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using relicarioApi.Models;

namespace relicarioApi.Domain.Handlers.System.Parameter
{
    public class ChangeParametersHandler : IRequestHandler<ChangeParametersRequest, ChangeParametersResponse>
    {
        private readonly IParametersRepository _parametersRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public ChangeParametersHandler(IParametersRepository ParametersRepository, IMapper mapper, IUnitOfWork uow)
        {
            _parametersRepository = ParametersRepository;
            _mapper = mapper;
            _uow = uow;
        }

        public Task<ChangeParametersResponse> Handle(ChangeParametersRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var Parameters = _mapper.Map<Parameters>(request);
                var result = _parametersRepository.Update(Parameters);
                _uow.Commit();
                return Task.FromResult(_mapper.Map<ChangeParametersResponse>(result));
            }
            catch (Exception e)
            {
                _uow.Rollback();
                Debug.WriteLine("ChangeParametersHandler: " + e.Message + " Stack: " + e.StackTrace);
                return Task.FromResult(new ChangeParametersResponse(false, e.Message));
            }
        }
    }
}

