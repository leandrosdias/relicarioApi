using AutoMapper;
using MediatR;
using relicarioApi.Data;
using relicarioApi.Domain.Commands.Requests.Loja.ProdutoFoto;
using relicarioApi.Domain.Commands.Responses.Loja.ProdutoFoto;
using relicarioApi.Models;
using relicarioApi.Repositories.Loja.Produtos;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace relicarioApi.Domain.Handlers.Loja.ProdutoFoto
{
    public class ChangeProdutoLojaFotoHandler : IRequestHandler<ChangeProdutoLojaFotoRequest, ChangeProdutoLojaFotoResponse>
    {
        private readonly IProdutoLojaFotoRepository _produtoLojaFotoRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public ChangeProdutoLojaFotoHandler(IProdutoLojaFotoRepository produtoLojaFotoRepository, IMapper mapper, IUnitOfWork uow)
        {
            _produtoLojaFotoRepository = produtoLojaFotoRepository;
            _mapper = mapper;
            _uow = uow;
        }

        public Task<ChangeProdutoLojaFotoResponse> Handle(ChangeProdutoLojaFotoRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var produtoLojaFoto = _mapper.Map<ProdutoLojaFoto>(request);

                var result = _produtoLojaFotoRepository.Update(produtoLojaFoto);
                _uow.Commit();
                return Task.FromResult(_mapper.Map<ChangeProdutoLojaFotoResponse>(result));
            }
            catch (Exception e)
            {
                _uow.Rollback();
                Debug.WriteLine("ChangeProdutoLojaFotoHandler: " + e.Message + " Stack: " + e.StackTrace);
                return Task.FromResult(new ChangeProdutoLojaFotoResponse(false, e.Message));
            }
        }
    }
}
