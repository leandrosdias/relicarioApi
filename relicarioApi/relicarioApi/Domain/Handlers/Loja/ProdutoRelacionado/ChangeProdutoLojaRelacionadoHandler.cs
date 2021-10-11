using AutoMapper;
using MediatR;
using relicarioApi.Data;
using relicarioApi.Domain.Commands.Requests.ProdutoLojaRelacionado;
using relicarioApi.Domain.Commands.Responses.ProdutoLojaRelacionado;
using relicarioApi.Repositories;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace relicarioApi.Domain.Handlers
{
    public class ChangeProdutoLojaRelacionadoHandler : IRequestHandler<ChangeProdutoLojaRelacionadoRequest, ChangeProdutoLojaRelacionadoResponse>
    {
        private readonly IProdutoLojaRelacionadoRepository _produtoLojaRelacionadoRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public ChangeProdutoLojaRelacionadoHandler(IProdutoLojaRelacionadoRepository produtoLojaRelacionadoRepository, IMapper mapper, IUnitOfWork uow)
        {
            _produtoLojaRelacionadoRepository = produtoLojaRelacionadoRepository;
            _mapper = mapper;
            _uow = uow;
        }

        public Task<ChangeProdutoLojaRelacionadoResponse> Handle(ChangeProdutoLojaRelacionadoRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var produtoLojaRelacionado = _mapper.Map<Models.ProdutoLojaRelacionado>(request);
                var result = _produtoLojaRelacionadoRepository.Update(produtoLojaRelacionado);
                _uow.Commit();
                return Task.FromResult(_mapper.Map<ChangeProdutoLojaRelacionadoResponse>(result));
            }
            catch (Exception e)
            {
                _uow.Rollback();
                Debug.WriteLine("ChangeProdutoLojaRelacionadoResponse: " + e.Message + " Stack: " + e.StackTrace);
                return Task.FromResult(new ChangeProdutoLojaRelacionadoResponse(false, e.Message));
            }
        }
    }
}
