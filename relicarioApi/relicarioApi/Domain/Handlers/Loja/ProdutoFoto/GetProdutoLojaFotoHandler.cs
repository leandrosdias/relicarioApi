using MediatR;
using relicarioApi.Domain.Commands.Requests.Loja.ProdutoFoto;
using relicarioApi.Domain.Commands.Responses.Loja.ProdutoFoto;
using relicarioApi.Repositories.Loja.Produtos;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace relicarioApi.Domain.Handlers.Loja.ProdutoFoto
{
    public class GetProdutoLojaFotoHandler : IRequestHandler<GetProdutoLojaFotoRequest, GetProdutoLojaFotoResponse>
    {
        private readonly IProdutoLojaFotoRepository _produtoLojaFotoRepository;

        public GetProdutoLojaFotoHandler(IProdutoLojaFotoRepository produtoLojaFotoRepository)
        {
            _produtoLojaFotoRepository = produtoLojaFotoRepository;
        }

        public async Task<GetProdutoLojaFotoResponse> Handle(GetProdutoLojaFotoRequest request, CancellationToken cancellationToken)
        {
            try
            {
                return await Task.FromResult(new GetProdutoLojaFotoResponse(_produtoLojaFotoRepository.Get(request)));
            }
            catch (Exception e)
            {
                Debug.WriteLine("GetProdutoLojaFotoResponse: " + e.Message + " Stack: " + e.StackTrace);
                return await Task.FromResult(new GetProdutoLojaFotoResponse(false, e.Message));
            }
        }
    }
}
