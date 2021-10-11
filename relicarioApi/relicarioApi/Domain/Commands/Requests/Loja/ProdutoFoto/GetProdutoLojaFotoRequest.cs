using MediatR;
using relicarioApi.Domain.Commands.Responses.Loja.ProdutoFoto;
using System;
using System.Collections.Generic;

namespace relicarioApi.Domain.Commands.Requests.Loja.ProdutoFoto
{
    public class GetProdutoLojaFotoRequest : IRequest<GetProdutoLojaFotoResponse>
    {
        public Guid Id { get; set; }
        public Guid ProdutoLojaId { get; set; }
    }
}