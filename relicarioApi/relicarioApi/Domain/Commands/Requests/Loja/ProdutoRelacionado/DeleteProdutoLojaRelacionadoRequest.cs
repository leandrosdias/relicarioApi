using MediatR;
using relicarioApi.Domain.Commands.Responses.ProdutoLojaRelacionado;
using System;

namespace relicarioApi.Domain.Commands.Requests.ProdutoLojaRelacionado
{
    public class DeleteProdutoLojaRelacionadoRequest : IRequest<DeleteProdutoLojaRelacionadoResponse>
    {
        public Guid Id { get; set; }
    }
}
