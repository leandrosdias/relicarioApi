using MediatR;
using relicarioApi.Domain.Commands.Requests.Home.Numeros;
using relicarioApi.Domain.Commands.Responses.Home.Numeros;
using relicarioApi.Repositories.Home.Numeros;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace relicarioApi.Domain.Handlers.Home.Numeros
{
    public class GetNumerosHandler : IRequestHandler<GetNumerosRequest, GetNumerosResponse>
    {
        private readonly INumerosRepository _numerosRepository;

        public GetNumerosHandler(INumerosRepository numerosRepository)
        {
            _numerosRepository = numerosRepository;
        }

        public async Task<GetNumerosResponse> Handle(GetNumerosRequest request, CancellationToken cancellationToken)
        {
            try
            {
                return await Task.FromResult(new GetNumerosResponse(_numerosRepository.Get(request)));
            }
            catch (Exception e)
            {
                Debug.WriteLine("GetNumerosResponse: " + e.Message + " Stack: " + e.StackTrace);
                return await Task.FromResult(new GetNumerosResponse(false, e.Message));
            }
        }
    }
}
