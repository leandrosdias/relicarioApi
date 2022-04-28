using AutoMapper;
using MediatR;
using relicarioApi.Data;
using relicarioApi.Domain.Commands.Requests.Galeria.Produtos;
using relicarioApi.Domain.Commands.Responses.Galeria.Produtos;
using relicarioApi.Models;
using relicarioApi.Repositories;
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
        private readonly IProdutoLojaRepository _produtoLojaRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public ChangeGaleriaProdutoHandler(IProdutoLojaRepository produtoLojaRepository, IGaleriaProdutoRepository galeriaProdutoRepository, IMapper mapper, IUnitOfWork uow)
        {
            _produtoLojaRepository = produtoLojaRepository;
            _galeriaProdutoRepository = galeriaProdutoRepository;
            _mapper = mapper;
            _uow = uow;
        }

        public Task<ChangeGaleriaProdutoResponse> Handle(ChangeGaleriaProdutoRequest request, CancellationToken cancellationToken)
        {
            try
            {
                if (request.ProdutoLojaId != Guid.Empty)
                {
                    var prodLoja = _produtoLojaRepository.Get(request.ProdutoLojaId);
                    if (prodLoja != null)
                    {
                        request.ProdutoLojaNome = prodLoja.Nome;
                    }
                }

                var galeriaProduto = _mapper.Map<ProdutoGaleria>(request);

                var prod = _galeriaProdutoRepository.FindByCodigo(galeriaProduto.Codigo);
                if (prod != null && prod.Id != request.Id)
                {
                    return Task.FromResult(new ChangeGaleriaProdutoResponse(false, $"Já existe produto da galeria cadastrado com o código: {galeriaProduto.Codigo}"));
                }

                if (string.IsNullOrWhiteSpace(request.Codigo))
                {
                    return Task.FromResult(new ChangeGaleriaProdutoResponse(false, $"O código do prooduto da galeria não pode ser nulo"));
                }

                var result = _galeriaProdutoRepository.Update(galeriaProduto);
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
