using MediatR;
using relicarioApi.Domain.Commands.Responses.Loja.ProdutoFoto;
using System;

namespace relicarioApi.Domain.Commands.Requests.Loja.ProdutoFoto
{
    public class DeleteProdutoLojaFotoRequest : IRequest<DeleteProdutoLojaFotoResponse>
    {
        public Guid Id { get; set; }
    }
}
