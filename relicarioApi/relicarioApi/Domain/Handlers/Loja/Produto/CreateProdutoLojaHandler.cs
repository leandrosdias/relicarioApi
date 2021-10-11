using AutoMapper;
using MediatR;
using relicarioApi.Data;
using relicarioApi.Domain.Commands.Requests.ProdutoLoja;
using relicarioApi.Domain.Commands.Responses.ProdutoLoja;
using relicarioApi.Repositories;
using System.Threading;
using System.Threading.Tasks;
using relicarioApi.Models;
using System;
using System.Diagnostics;

namespace relicarioApi.Domain.Handlers
{
    public class CreateProdutoLojaHandler : IRequestHandler<CreateProdutoLojaRequest, CreateProdutoLojaResponse>
    {
        private readonly IProdutoLojaRepository _produtoLojaRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public CreateProdutoLojaHandler(IProdutoLojaRepository produtoLojaRepository, IMapper mapper, IUnitOfWork uow)
        {
            _produtoLojaRepository = produtoLojaRepository;
            _mapper = mapper;
            _uow = uow;
        }

        public Task<CreateProdutoLojaResponse> Handle(CreateProdutoLojaRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var produtoLoja = _mapper.Map<Models.ProdutoLoja>(request);

                if (_produtoLojaRepository.FindByCodigo(produtoLoja.Codigo) != null)
                {
                    return Task.FromResult(new CreateProdutoLojaResponse(false, $"Já existe categoria cadastrada com o código: {produtoLoja.Codigo}"));
                }

                _produtoLojaRepository.Save(produtoLoja);
                _uow.Commit();
                return Task.FromResult(_mapper.Map<CreateProdutoLojaResponse>(produtoLoja));
            }
            catch (Exception e)
            {
                _uow.Rollback();
                Debug.WriteLine("CreateProdutoLojaHandler: " + e.Message + " Stack: " + e.StackTrace);
                return Task.FromResult(new CreateProdutoLojaResponse(false, e.Message));
            }
        }
    }
}
