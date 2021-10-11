using MediatR;
using relicarioApi.Domain.Commands.Responses.Galeria.ProdutoFoto;
using System;
using System.Collections.Generic;

namespace relicarioApi.Domain.Commands.Requests.Galeria.ProdutoFoto
{
    public class GetProdutoGaleriaFotoRequest : IRequest<GetProdutoGaleriaFotoResponse>
    {
        public Guid Id { get; set; }
        public Guid ProdutoGaleriaId { get; set; }
    }
}