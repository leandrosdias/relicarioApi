using AutoMapper;
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
    public class CreateParametersHandler : IRequestHandler<CreateParametersRequest, CreateParametersResponse>
    {
        private readonly IParametersRepository _parametersRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public CreateParametersHandler(IParametersRepository parametersRepository, IMapper mapper, IUnitOfWork uow)
        {
            _parametersRepository = parametersRepository;
            _mapper = mapper;
            _uow = uow;
        }

        public Task<CreateParametersResponse> Handle(CreateParametersRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var parameters = _mapper.Map<Models.Parameters>(request);

                _parametersRepository.Save(parameters);
                _uow.Commit();
                return Task.FromResult(_mapper.Map<CreateParametersResponse>(parameters));
            }
            catch (Exception e)
            {
                _uow.Rollback();
                Debug.WriteLine("CreateParametersResponse: " + e.Message + " Stack: " + e.StackTrace);
                return Task.FromResult(new CreateParametersResponse(false, e.Message));
            }
        }
    }
}
