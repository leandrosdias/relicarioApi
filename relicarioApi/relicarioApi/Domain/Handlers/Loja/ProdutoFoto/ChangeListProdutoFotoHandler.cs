using AutoMapper;
using MediatR;
using relicarioApi.Data;
using relicarioApi.Domain.Commands.Requests.Loja.ProdutoFoto;
using relicarioApi.Domain.Commands.Responses.Loja.ProdutoFoto;
using relicarioApi.Models;
using relicarioApi.Repositories.Loja.Produtos;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace relicarioApi.Domain.Handlers.Loja.ProdutoFoto
{
    public class ChangeListProdutoFotoHandler : IRequestHandler<ChangeListProdutoFotoRequest, ChangeListProdutoFotoResponse>
    {
        private readonly IProdutoLojaFotoRepository _produtoLojaFotoRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public ChangeListProdutoFotoHandler(IProdutoLojaFotoRepository produtoLojaFotoRepository, IMapper mapper, IUnitOfWork uow)
        {
            _produtoLojaFotoRepository = produtoLojaFotoRepository;
            _mapper = mapper;
            _uow = uow;
        }

        public Task<ChangeListProdutoFotoResponse> Handle(ChangeListProdutoFotoRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var prodDbList = _produtoLojaFotoRepository.Get(new GetProdutoLojaFotoRequest { ProdutoLojaId = request.ProdutoLojaId }).ToList();
                foreach (var prodDb in prodDbList)
                {
                    _produtoLojaFotoRepository.Delete(prodDb.Id);
                }

                foreach (var reqItem in request.Produtos)
                {
                    reqItem.ProdutoLojaId = request.ProdutoLojaId;
                    var produtoLojaFoto = _mapper.Map<ProdutoLojaFoto>(reqItem);
                    _produtoLojaFotoRepository.Save(produtoLojaFoto);
                }

                _uow.Commit();
                return Task.FromResult(new ChangeListProdutoFotoResponse());
            }
            catch (Exception e)
            {
                _uow.Rollback();
                Debug.WriteLine("ChangeListProdutoFotoResponse: " + e.Message + " Stack: " + e.StackTrace);
                return Task.FromResult(new ChangeListProdutoFotoResponse(false, e.Message));
            }
        }
    }
}
