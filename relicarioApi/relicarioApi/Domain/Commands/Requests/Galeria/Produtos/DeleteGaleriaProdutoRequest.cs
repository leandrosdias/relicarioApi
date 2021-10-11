using MediatR;
using relicarioApi.Domain.Commands.Responses.Galeria.Produtos;
using System;

namespace relicarioApi.Domain.Commands.Requests.Galeria.Produtos
{
    public class DeleteGaleriaProdutoRequest : IRequest<DeleteGaleriaProdutoResponse>
    {
        public Guid Id { get; set; }
    }
}
