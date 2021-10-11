using MediatR;
using relicarioApi.Domain.Commands.Responses.ProdutoLojaAtributo;
using System;

namespace relicarioApi.Domain.Commands.Requests.ProdutoLojaAtributo
{
    public class DeleteProdutoLojaAtributoRequest : IRequest<DeleteProdutoLojaAtributoResponse>
    {
        public Guid Id { get; set; }
    }
}
