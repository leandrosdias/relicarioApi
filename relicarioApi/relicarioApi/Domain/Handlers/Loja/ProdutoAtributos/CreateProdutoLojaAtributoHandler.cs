using AutoMapper;
using MediatR;
using relicarioApi.Data;
using relicarioApi.Domain.Commands.Requests.ProdutoLojaAtributo;
using relicarioApi.Domain.Commands.Responses.ProdutoLojaAtributo;
using relicarioApi.Repositories;
using System.Threading;
using System.Threading.Tasks;
using relicarioApi.Models;
using System;
using System.Diagnostics;

namespace relicarioApi.Domain.Handlers
{
    public class CreateProdutoLojaAtributoHandler : IRequestHandler<CreateProdutoLojaAtributoRequest, CreateProdutoLojaAtributoResponse>
    {
        private readonly IProdutoLojaAtributoRepository _produtoLojaAtributoRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public CreateProdutoLojaAtributoHandler(IProdutoLojaAtributoRepository produtoLojaAtributoRepository, IMapper mapper, IUnitOfWork uow)
        {
            _produtoLojaAtributoRepository = produtoLojaAtributoRepository;
            _mapper = mapper;
            _uow = uow;
        }

        public Task<CreateProdutoLojaAtributoResponse> Handle(CreateProdutoLojaAtributoRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var produtoLojaAtributo = _mapper.Map<Models.ProdutoLojaAtributo>(request);

                _produtoLojaAtributoRepository.Save(produtoLojaAtributo);
                _uow.Commit();
                return Task.FromResult(_mapper.Map<CreateProdutoLojaAtributoResponse>(produtoLojaAtributo));
            }
            catch (Exception e)
            {
                _uow.Rollback();
                Debug.WriteLine("CreateProdutoLojaAtributoHandler: " + e.Message + " Stack: " + e.StackTrace);
                return Task.FromResult(new CreateProdutoLojaAtributoResponse(false, e.Message));
            }
        }
    }
}
