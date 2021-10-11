using AutoMapper;
using MediatR;
using relicarioApi.Data;
using relicarioApi.Domain.Commands.Requests.Galeria.ProdutoFoto;
using relicarioApi.Domain.Commands.Responses.Galeria.ProdutoFoto;
using relicarioApi.Models;
using relicarioApi.Repositories.Galeria.Produtos;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace relicarioApi.Domain.Handlers.Galeria.ProdutoFoto
{
    public class CreateProdutoGaleriaFotoHandler : IRequestHandler<CreateProdutoGaleriaFotoRequest, CreateProdutoGaleriaFotoResponse>
    {
        private readonly IProdutoGaleriaFotoRepository _produtoGaleriaFotoRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public CreateProdutoGaleriaFotoHandler(IProdutoGaleriaFotoRepository produtoGaleriaFotoRepository, IMapper mapper, IUnitOfWork uow)
        {
            _produtoGaleriaFotoRepository = produtoGaleriaFotoRepository;
            _mapper = mapper;
            _uow = uow;
        }

        public Task<CreateProdutoGaleriaFotoResponse> Handle(CreateProdutoGaleriaFotoRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var produtoGaleriaFoto = _mapper.Map<ProdutoGaleriaFoto>(request);
                _produtoGaleriaFotoRepository.Save(produtoGaleriaFoto);
                _uow.Commit();
                return Task.FromResult(_mapper.Map<CreateProdutoGaleriaFotoResponse>(produtoGaleriaFoto));
            }
            catch (Exception e)
            {
                _uow.Rollback();
                Debug.WriteLine("CreateProdutoGaleriaFotoResponse: " + e.Message + " Stack: " + e.StackTrace);
                return Task.FromResult(new CreateProdutoGaleriaFotoResponse(false, e.Message));
            }
        }
    }
}
