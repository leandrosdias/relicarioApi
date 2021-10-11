using MediatR;
using relicarioApi.Domain.Commands.Requests.Galeria.ProdutoFoto;
using relicarioApi.Domain.Commands.Responses.Galeria.ProdutoFoto;
using relicarioApi.Repositories.Galeria.Produtos;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace relicarioApi.Domain.Handlers.Galeria.ProdutoFoto
{
    public class GetProdutoGaleriaFotoHandler : IRequestHandler<GetProdutoGaleriaFotoRequest, GetProdutoGaleriaFotoResponse>
    {
        private readonly IProdutoGaleriaFotoRepository _produtoGaleriaFotoRepository;

        public GetProdutoGaleriaFotoHandler(IProdutoGaleriaFotoRepository produtoGaleriaFotoRepository)
        {
            _produtoGaleriaFotoRepository = produtoGaleriaFotoRepository;
        }

        public async Task<GetProdutoGaleriaFotoResponse> Handle(GetProdutoGaleriaFotoRequest request, CancellationToken cancellationToken)
        {
            try
            {
                return await Task.FromResult(new GetProdutoGaleriaFotoResponse(_produtoGaleriaFotoRepository.Get(request)));
            }
            catch (Exception e)
            {
                Debug.WriteLine("GetProdutoGaleriaFotoResponse: " + e.Message + " Stack: " + e.StackTrace);
                return await Task.FromResult(new GetProdutoGaleriaFotoResponse(false, e.Message));
            }
        }
    }
}
