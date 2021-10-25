using MediatR;
using relicarioApi.Domain.Commands.Requests.System.Parameter;
using relicarioApi.Domain.Commands.Responses.System.Parameter;
using relicarioApi.Repositories.System.Parameter;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace relicarioApi.Domain.Handlers.System.Parameter
{
    public class GetParametersHandler : IRequestHandler<GetParametersRequest, GetParametersResponse>
    {
        private readonly IParametersRepository _parametersRepository;

        public GetParametersHandler(IParametersRepository ParametersRepository)
        {
            _parametersRepository = ParametersRepository;
        }

        public async Task<GetParametersResponse> Handle(GetParametersRequest request, CancellationToken cancellationToken)
        {
            try
            {
                return await Task.FromResult(new GetParametersResponse(_parametersRepository.Get(request)));
            }
            catch (Exception e)
            {
                Debug.WriteLine("GetParametersResponse: " + e.Message + " Stack: " + e.StackTrace);
                return await Task.FromResult(new GetParametersResponse(false, e.Message));
            }
        }
    }
}
