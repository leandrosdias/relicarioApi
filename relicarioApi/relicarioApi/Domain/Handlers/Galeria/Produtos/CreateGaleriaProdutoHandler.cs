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
    public class CreateGaleriaProdutoHandler : IRequestHandler<CreateGaleriaProdutoRequest, CreateGaleriaProdutoResponse>
    {
        private readonly IGaleriaProdutoRepository _galeriaProdutoRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public CreateGaleriaProdutoHandler(IGaleriaProdutoRepository galeriaProdutoRepository, IMapper mapper, IUnitOfWork uow)
        {
            _galeriaProdutoRepository = galeriaProdutoRepository;
            _mapper = mapper;
            _uow = uow;
        }

        public Task<CreateGaleriaProdutoResponse> Handle(CreateGaleriaProdutoRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var galeriaProduto = _mapper.Map<ProdutoGaleria>(request);

                if (_galeriaProdutoRepository.FindByNome(galeriaProduto.Nome) != null)
                {
                    return Task.FromResult(new CreateGaleriaProdutoResponse(false, $"Já existe produto cadastrado com o nome: {galeriaProduto.Nome}"));
                }

                if (_galeriaProdutoRepository.FindByCodigo(galeriaProduto.Codigo) != null)
                {
                    return Task.FromResult(new CreateGaleriaProdutoResponse(false, $"Já existe produto cadastrado com o código: {galeriaProduto.Codigo}"));
                }

                if (string.IsNullOrWhiteSpace(request.Codigo))
                {
                    return Task.FromResult(new CreateGaleriaProdutoResponse(false, $"O código da produto não pode ser nulo"));
                }

                _galeriaProdutoRepository.Save(galeriaProduto);
                _uow.Commit();
                return Task.FromResult(_mapper.Map<CreateGaleriaProdutoResponse>(galeriaProduto));
            }
            catch (Exception e)
            {
                _uow.Rollback();
                Debug.WriteLine("CreateGaleriaProdutoResponse: " + e.Message + " Stack: " + e.StackTrace);
                return Task.FromResult(new CreateGaleriaProdutoResponse(false, e.Message));
            }
        }
    }
}
