using AutoMapper;
using MediatR;
using relicarioApi.Data;
using relicarioApi.Domain.Commands.Requests;
using relicarioApi.Domain.Commands.Responses;
using relicarioApi.Models;
using relicarioApi.Repositories;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

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
                var produtoLoja = _mapper.Map<ProdutoLoja>(request);
                _produtoLojaRepository.Save(produtoLoja);
                _uow.Commit();
                return Task.FromResult(_mapper.Map<CreateProdutoLojaResponse>(produtoLoja));
            }
            catch (Exception e)
            {
                _uow.Rollback();
                Debug.WriteLine("CreateProdutoLoja: " + e.Message + " Stack: " + e.StackTrace);
                return Task.FromResult(new CreateProdutoLojaResponse(false, e.Message));
            }
        }
    }
}
