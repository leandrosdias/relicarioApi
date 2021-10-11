using MediatR;
using relicarioApi.Domain.Commands.Requests.ProdutoLoja;
using relicarioApi.Domain.Commands.Responses.ProdutoLoja;
using relicarioApi.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace relicarioApi.Domain.Handlers.ProdutoLoja
{
    public class GetProdutoLojaHandler : IRequestHandler<GetProdutoLojaRequest, GetProdutoLojaResponse>
    {
        private readonly IProdutoLojaRepository _produtoLojaRepository;

        public GetProdutoLojaHandler(IProdutoLojaRepository produtoLojaRepository)
        {
            _produtoLojaRepository = produtoLojaRepository;
        }

        public async Task<GetProdutoLojaResponse> Handle(GetProdutoLojaRequest request, CancellationToken cancellationToken)
        {
            try
            {
                return await Task.FromResult(new GetProdutoLojaResponse(_produtoLojaRepository.Get(request)));
            }
            catch (Exception e)
            {
                Debug.WriteLine($"{nameof(GetProdutoLojaResponse)}  - {e.Message} Stack: {e.StackTrace} ");
                return await Task.FromResult(new GetProdutoLojaResponse(false, e.Message));
            }
        }
    }
}
