using MediatR;
using relicarioApi.Domain.Commands.Responses.ProdutoLoja;
using System;

namespace relicarioApi.Domain.Commands.Requests.ProdutoLoja
{
    public class DeleteProdutoLojaRequest : IRequest<DeleteProdutoLojaResponse>
    {
        public Guid Id { get; set; }
    }
}
