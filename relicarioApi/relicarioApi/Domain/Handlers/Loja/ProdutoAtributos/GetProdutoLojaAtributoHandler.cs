using MediatR;
using relicarioApi.Domain.Commands.Requests.ProdutoLojaAtributo;
using relicarioApi.Domain.Commands.Responses.ProdutoLojaAtributo;
using relicarioApi.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace relicarioApi.Domain.Handlers.ProdutoLojaAtributo
{
    public class GetProdutoLojaAtributoHandler : IRequestHandler<GetProdutoLojaAtributoRequest, GetProdutoLojaAtributoResponse>
    {
        private readonly IProdutoLojaAtributoRepository _produtoLojaAtributoRepository;

        public GetProdutoLojaAtributoHandler(IProdutoLojaAtributoRepository produtoLojaAtributoRepository)
        {
            _produtoLojaAtributoRepository = produtoLojaAtributoRepository;
        }

        public async Task<GetProdutoLojaAtributoResponse> Handle(GetProdutoLojaAtributoRequest request, CancellationToken cancellationToken)
        {
            try
            {
                return await Task.FromResult(new GetProdutoLojaAtributoResponse(_produtoLojaAtributoRepository.Get(request), request.SelectDistinct));
            }
            catch (Exception e)
            {
                Debug.WriteLine($"{nameof(GetProdutoLojaAtributoResponse)}  - {e.Message} Stack: {e.StackTrace} ");
                return await Task.FromResult(new GetProdutoLojaAtributoResponse(false, e.Message));
            }
        }
    }
}
