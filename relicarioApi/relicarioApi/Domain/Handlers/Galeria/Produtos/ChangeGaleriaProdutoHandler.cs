using AutoMapper;
using MediatR;
using relicarioApi.Data;
using relicarioApi.Domain.Commands.Requests.Galeria.Produtos;
using relicarioApi.Domain.Commands.Responses.Galeria.Produtos;
using relicarioApi.Models;
using relicarioApi.Repositories.Galeria.Produtos;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace relicarioApi.Domain.Handlers.Galeria.Produtos
{
    public class ChangeGaleriaProdutoHandler : IRequestHandler<ChangeGaleriaProdutoRequest, ChangeGaleriaProdutoResponse>
    {
        private readonly IGaleriaProdutoRepository _galeriaProdutoRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public ChangeGaleriaProdutoHandler(IGaleriaProdutoRepository galeriaProdutoRepository, IMapper mapper, IUnitOfWork uow)
        {
            _galeriaProdutoRepository = galeriaProdutoRepository;
            _mapper = mapper;
            _uow = uow;
        }

        public Task<ChangeGaleriaProdutoResponse> Handle(ChangeGaleriaProdutoRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var GaleriaProduto = _mapper.Map<ProdutoGaleria>(request);

                if (_galeriaProdutoRepository.FindByCodigo(GaleriaProduto.Codigo)?.Id != request.Id)
                {
                    return Task.FromResult(new ChangeGaleriaProdutoResponse(false, $"Já existe categoria cadastrado com o código: {GaleriaProduto.Codigo}"));
                }

                if (request.Codigo == 0)
                {
                    return Task.FromResult(new ChangeGaleriaProdutoResponse(false, $"O código da categoria não pode ser nulo"));
                }


                var result = _galeriaProdutoRepository.Update(GaleriaProduto);
                _uow.Commit();
                return Task.FromResult(_mapper.Map<ChangeGaleriaProdutoResponse>(result));
            }
            catch (Exception e)
            {
                _uow.Rollback();
                Debug.WriteLine("ChangeGaleriaProdutoHandler: " + e.Message + " Stack: " + e.StackTrace);
                return Task.FromResult(new ChangeGaleriaProdutoResponse(false, e.Message));
            }
        }
    }
}
