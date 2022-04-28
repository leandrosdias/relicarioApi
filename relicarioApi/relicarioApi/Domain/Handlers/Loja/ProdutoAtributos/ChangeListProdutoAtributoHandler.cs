using AutoMapper;
using MediatR;
using relicarioApi.Data;
using relicarioApi.Domain.Commands.Requests.Loja.ProdutoAtributo;
using relicarioApi.Domain.Commands.Requests.ProdutoLojaAtributo;
using relicarioApi.Domain.Commands.Responses.Loja.ProdutoAtributos;
using relicarioApi.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace relicarioApi.Domain.Handlers.Loja.ProdutoAtributos
{
    public class ChangeListProdutoAtributoHandler : IRequestHandler<ChangeListProdutoAtributoRequest, ChangeListProdutoAtributoResponse>
    {
        private readonly IProdutoLojaAtributoRepository _produtoLojaAtributoRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public ChangeListProdutoAtributoHandler(IProdutoLojaAtributoRepository produtoLojaAtributoRepository, IMapper mapper, IUnitOfWork uow)
        {
            _produtoLojaAtributoRepository = produtoLojaAtributoRepository;
            _mapper = mapper;
            _uow = uow;
        }

        public Task<ChangeListProdutoAtributoResponse> Handle(ChangeListProdutoAtributoRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var prodDbList = _produtoLojaAtributoRepository.Get(new GetProdutoLojaAtributoRequest { ProdutoLojaId = request.ProdutoLojaId }).ToList();
                foreach (var prodDb in prodDbList)
                {
                    _produtoLojaAtributoRepository.Delete(prodDb.Id);
                }

                foreach (var reqItem in request.Produtos)
                {
                    reqItem.ProdutoLojaId = request.ProdutoLojaId;
                    var produtoLojaFoto = _mapper.Map<Models.ProdutoLojaAtributo>(reqItem);
                    _produtoLojaAtributoRepository.Save(produtoLojaFoto);
                }

                _uow.Commit();
                return Task.FromResult(new ChangeListProdutoAtributoResponse());
            }
            catch (Exception e)
            {
                _uow.Rollback();
                Debug.WriteLine("ChangeListProdutoFotoResponse: " + e.Message + " Stack: " + e.StackTrace);
                return Task.FromResult(new ChangeListProdutoAtributoResponse(false, e.Message));
            }
        }
    }
}
