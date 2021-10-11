using MediatR;
using relicarioApi.Domain.Commands.Responses.Galeria.ProdutoFoto;
using System;

namespace relicarioApi.Domain.Commands.Requests.Galeria.ProdutoFoto
{
    public class DeleteProdutoGaleriaFotoRequest : IRequest<DeleteProdutoGaleriaFotoResponse>
    {
        public Guid Id { get; set; }
    }
}
