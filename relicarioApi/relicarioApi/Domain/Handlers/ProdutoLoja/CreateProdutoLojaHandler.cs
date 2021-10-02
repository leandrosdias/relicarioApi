using AutoMapper;
using MediatR;
using relicarioApi.Domain.Commands.Requests;
using relicarioApi.Domain.Commands.Responses;
using relicarioApi.Models;
using relicarioApi.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace relicarioApi.Domain.Handlers
{
    public class CreateProdutoLojaHandler : IRequestHandler<CreateProdutoLojaRequest, CreateProdutoLojaResponse>
    {
        private IProdutoLojaRepository _produtoLojaRepository;
        private IMapper _mapper;

        public CreateProdutoLojaHandler(IProdutoLojaRepository produtoLojaRepository, IMapper mapper)
        {
            _produtoLojaRepository = produtoLojaRepository;
            _mapper = mapper;
        }

        public Task<CreateProdutoLojaResponse> Handle(CreateProdutoLojaRequest request, CancellationToken cancellationToken)
        {
            var produtoLoja = _mapper.Map<ProdutoLoja>(request);
            _produtoLojaRepository.Save(produtoLoja);


            return Task.FromResult(_mapper.Map<CreateProdutoLojaResponse>(produtoLoja));
        }
    }
}
