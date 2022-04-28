using MediatR;
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
    public class GetDepoimentoHandler : IRequestHandler<GetDepoimentoRequest, GetDepoimentoResponse>
    {
        private readonly IDepoimentoRepository _depoimentoRepository;

        public GetDepoimentoHandler(IDepoimentoRepository depoimentoRepository)
        {
            _depoimentoRepository = depoimentoRepository;
        }

        public async Task<GetDepoimentoResponse> Handle(GetDepoimentoRequest request, CancellationToken cancellationToken)
        {
            try
            {
                return await Task.FromResult(new GetDepoimentoResponse(_depoimentoRepository.Get(request)));
            }
            catch (Exception e)
            {
                Debug.WriteLine("GetDepoimentoResponse: " + e.Message + " Stack: " + e.StackTrace);
                return await Task.FromResult(new GetDepoimentoResponse(false, e.Message));
            }
        }
    }
}
