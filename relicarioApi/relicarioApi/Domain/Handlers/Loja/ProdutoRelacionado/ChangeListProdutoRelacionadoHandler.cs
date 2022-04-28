using AutoMapper;
using MediatR;
using relicarioApi.Data;
using relicarioApi.Domain.Commands.Requests.Loja.ProdutoRelacionado;
using relicarioApi.Domain.Commands.Requests.ProdutoLojaRelacionado;
using relicarioApi.Domain.Commands.Responses.Loja.ProdutoRelacionado;
using relicarioApi.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace relicarioApi.Domain.Handlers.Loja.ProdutoRelacionado
{
    public class ChangeListProdutoRelacionadoHandler : IRequestHandler<ChangeListProdutoRelacionadoRequest, ChangeListProdutoRelacionadoResponse>
    {
        private readonly IProdutoLojaRelacionadoRepository _produtoLojaRelacionadoRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public ChangeListProdutoRelacionadoHandler(IProdutoLojaRelacionadoRepository produtoLojaRelacionadoRepository, IMapper mapper, IUnitOfWork uow)
        {
            _produtoLojaRelacionadoRepository = produtoLojaRelacionadoRepository;
            _mapper = mapper;
            _uow = uow;
        }

        public Task<ChangeListProdutoRelacionadoResponse> Handle(ChangeListProdutoRelacionadoRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var prodDbList = _produtoLojaRelacionadoRepository.Get(new GetProdutoLojaRelacionadoRequest { ProdutoPrincipalId = request.ProdutoLojaId }).ToList();
                foreach (var prodDb in prodDbList)
                {
                    _produtoLojaRelacionadoRepository.Delete(prodDb.Id);
                }

                foreach (var reqItem in request.ProdutosRelacionados)
                {
                    reqItem.ProdutoPrincipalId = request.ProdutoLojaId;
                    var produtoLojaRel = _mapper.Map<Models.ProdutoLojaRelacionado>(reqItem);
                    _produtoLojaRelacionadoRepository.Save(produtoLojaRel);
                }

                _uow.Commit();
                return Task.FromResult(new ChangeListProdutoRelacionadoResponse());
            }
            catch (Exception e)
            {
                _uow.Rollback();
                Debug.WriteLine("ChangeListProdutoRelacionadoResponse: " + e.Message + " Stack: " + e.StackTrace);
                return Task.FromResult(new ChangeListProdutoRelacionadoResponse(false, e.Message));
            }
        }
    }
}
