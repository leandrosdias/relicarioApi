using AutoMapper;
using MediatR;
using relicarioApi.Data;
using relicarioApi.Domain.Commands.Requests.Galeria.ProdutoFoto;
using relicarioApi.Domain.Commands.Responses.Galeria.ProdutoFoto;
using relicarioApi.Models;
using relicarioApi.Repositories.Galeria.Produtos;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace relicarioApi.Domain.Handlers.Galeria.ProdutoFoto
{
    public class ChangeListProdutoGaleriaFotoHandler : IRequestHandler<ChangeListProdutoGaleriaFotoRequest, ChangeListProdutoGaleriaFotoResponse>
    {
        private readonly IProdutoGaleriaFotoRepository _produtoLojaGaleriaRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public ChangeListProdutoGaleriaFotoHandler(IProdutoGaleriaFotoRepository produtoLojaGaleriaRepository, IMapper mapper, IUnitOfWork uow)
        {
            _produtoLojaGaleriaRepository = produtoLojaGaleriaRepository;
            _mapper = mapper;
            _uow = uow;
        }

        public Task<ChangeListProdutoGaleriaFotoResponse> Handle(ChangeListProdutoGaleriaFotoRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var prodDbList = _produtoLojaGaleriaRepository.Get(new GetProdutoGaleriaFotoRequest { ProdutoGaleriaId = request.ProdutoLojaId }).ToList();
                foreach (var prodDb in prodDbList)
                {
                    _produtoLojaGaleriaRepository.Delete(prodDb.Id);
                }

                foreach (var reqItem in request.Produtos)
                {
                    reqItem.ProdutoGaleriaId = request.ProdutoLojaId;
                    var produtoLojaFoto = _mapper.Map<ProdutoGaleriaFoto>(reqItem);
                    _produtoLojaGaleriaRepository.Save(produtoLojaFoto);
                }

                _uow.Commit();
                return Task.FromResult(new ChangeListProdutoGaleriaFotoResponse());
            }
            catch (Exception e)
            {
                _uow.Rollback();
                Debug.WriteLine("ChangeListProdutoGaleriaFotoResponse: " + e.Message + " Stack: " + e.StackTrace);
                return Task.FromResult(new ChangeListProdutoGaleriaFotoResponse(false, e.Message));
            }
        }
    }
}
