using MediatR;
using relicarioApi.Domain.Commands.Requests.Galeria.Produtos;
using relicarioApi.Domain.Commands.Responses.Galeria.Produtos;
using relicarioApi.Repositories.Galeria.Produtos;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace relicarioApi.Domain.Handlers.Galeria.Produtos
{
    public class GetGaleriaProdutoHandler : IRequestHandler<GetGaleriaProdutoRequest, GetGaleriaProdutoResponse>
    {
        private readonly IGaleriaProdutoRepository _galeriaProdutoRepository;

        public GetGaleriaProdutoHandler(IGaleriaProdutoRepository galeriaProdutoRepository)
        {
            _galeriaProdutoRepository = galeriaProdutoRepository;
        }

        public async Task<GetGaleriaProdutoResponse> Handle(GetGaleriaProdutoRequest request, CancellationToken cancellationToken)
        {
            try
            {
                return await Task.FromResult(new GetGaleriaProdutoResponse(_galeriaProdutoRepository.Get(request)));
            }
            catch (Exception e)
            {
                Debug.WriteLine("GetGaleriaProdutoResponse: " + e.Message + " Stack: " + e.StackTrace);
                return await Task.FromResult(new GetGaleriaProdutoResponse(false, e.Message));
            }
        }
    }
}
