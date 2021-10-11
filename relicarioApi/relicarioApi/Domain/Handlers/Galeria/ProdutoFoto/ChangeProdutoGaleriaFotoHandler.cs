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
    public class ChangeProdutoGaleriaFotoHandler : IRequestHandler<ChangeProdutoGaleriaFotoRequest, ChangeProdutoGaleriaFotoResponse>
    {
        private readonly IProdutoGaleriaFotoRepository _produtoGaleriaFotoRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public ChangeProdutoGaleriaFotoHandler(IProdutoGaleriaFotoRepository produtoGaleriaFotoRepository, IMapper mapper, IUnitOfWork uow)
        {
            _produtoGaleriaFotoRepository = produtoGaleriaFotoRepository;
            _mapper = mapper;
            _uow = uow;
        }

        public Task<ChangeProdutoGaleriaFotoResponse> Handle(ChangeProdutoGaleriaFotoRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var produtoGaleriaFoto = _mapper.Map<ProdutoGaleriaFoto>(request);

                var result = _produtoGaleriaFotoRepository.Update(produtoGaleriaFoto);
                _uow.Commit();
                return Task.FromResult(_mapper.Map<ChangeProdutoGaleriaFotoResponse>(result));
            }
            catch (Exception e)
            {
                _uow.Rollback();
                Debug.WriteLine("ChangeProdutoGaleriaFotoHandler: " + e.Message + " Stack: " + e.StackTrace);
                return Task.FromResult(new ChangeProdutoGaleriaFotoResponse(false, e.Message));
            }
        }
    }
}
