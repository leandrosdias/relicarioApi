using MediatR;
using relicarioApi.Domain.Commands.Requests.ProdutoLojaRelacionado;
using relicarioApi.Domain.Commands.Responses.ProdutoLojaRelacionado;
using relicarioApi.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace relicarioApi.Domain.Handlers.ProdutoLojaRelacionado
{
    public class GetProdutoLojaRelacionadoHandler : IRequestHandler<GetProdutoLojaRelacionadoRequest, GetProdutoLojaRelacionadoResponse>
    {
        private readonly IProdutoLojaRelacionadoRepository _produtoLojaRelacionadoRepository;

        public GetProdutoLojaRelacionadoHandler(IProdutoLojaRelacionadoRepository produtoLojaRelacionadoRepository)
        {
            _produtoLojaRelacionadoRepository = produtoLojaRelacionadoRepository;
        }

        public async Task<GetProdutoLojaRelacionadoResponse> Handle(GetProdutoLojaRelacionadoRequest request, CancellationToken cancellationToken)
        {
            try
            {
                return await Task.FromResult(new GetProdutoLojaRelacionadoResponse(_produtoLojaRelacionadoRepository.Get(request)));
            }
            catch (Exception e)
            {
                Debug.WriteLine($"{nameof(GetProdutoLojaRelacionadoResponse)}  - {e.Message} Stack: {e.StackTrace} ");
                return await Task.FromResult(new GetProdutoLojaRelacionadoResponse(false, e.Message));
            }
        }
    }
}
