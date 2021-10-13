using MediatR;
using relicarioApi.Domain.Commands.Requests.Home.Valores;
using relicarioApi.Domain.Commands.Responses.Home.Valores;
using relicarioApi.Repositories.Home.Valores;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace relicarioApi.Domain.Handlers.Home.Valores
{
    public class GetValoresHandler : IRequestHandler<GetValoresRequest, GetValoresResponse>
    {
        private readonly IValoresRepository _valoresRepository;

        public GetValoresHandler(IValoresRepository valoresRepository)
        {
            _valoresRepository = valoresRepository;
        }

        public async Task<GetValoresResponse> Handle(GetValoresRequest request, CancellationToken cancellationToken)
        {
            try
            {
                return await Task.FromResult(new GetValoresResponse(_valoresRepository.Get(request)));
            }
            catch (Exception e)
            {
                Debug.WriteLine("GetValoresResponse: " + e.Message + " Stack: " + e.StackTrace);
                return await Task.FromResult(new GetValoresResponse(false, e.Message));
            }
        }
    }
}
