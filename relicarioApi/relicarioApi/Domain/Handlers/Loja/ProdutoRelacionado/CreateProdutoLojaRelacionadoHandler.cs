using AutoMapper;
using MediatR;
using relicarioApi.Data;
using relicarioApi.Domain.Commands.Requests.ProdutoLojaRelacionado;
using relicarioApi.Domain.Commands.Responses.ProdutoLojaRelacionado;
using relicarioApi.Repositories;
using System.Threading;
using System.Threading.Tasks;
using relicarioApi.Models;
using System;
using System.Diagnostics;

namespace relicarioApi.Domain.Handlers
{
    public class CreateProdutoLojaRelacionadoHandler : IRequestHandler<CreateProdutoLojaRelacionadoRequest, CreateProdutoLojaRelacionadoResponse>
    {
        private readonly IProdutoLojaRelacionadoRepository _produtoLojaRelacionadoRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public CreateProdutoLojaRelacionadoHandler(IProdutoLojaRelacionadoRepository produtoLojaRelacionadoRepository, IMapper mapper, IUnitOfWork uow)
        {
            _produtoLojaRelacionadoRepository = produtoLojaRelacionadoRepository;
            _mapper = mapper;
            _uow = uow;
        }

        public Task<CreateProdutoLojaRelacionadoResponse> Handle(CreateProdutoLojaRelacionadoRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var produtoLojaRelacionado = _mapper.Map<Models.ProdutoLojaRelacionado>(request);

                _produtoLojaRelacionadoRepository.Save(produtoLojaRelacionado);
                _uow.Commit();
                return Task.FromResult(_mapper.Map<CreateProdutoLojaRelacionadoResponse>(produtoLojaRelacionado));
            }
            catch (Exception e)
            {
                _uow.Rollback();
                Debug.WriteLine("CreateProdutoLojaRelacionadoHandler: " + e.Message + " Stack: " + e.StackTrace);
                return Task.FromResult(new CreateProdutoLojaRelacionadoResponse(false, e.Message));
            }
        }
    }
}
