using MediatR;
using relicarioApi.Domain.Commands.Responses.ProdutoLojaRelacionado;
using System;
using System.Collections.Generic;

namespace relicarioApi.Domain.Commands.Requests.ProdutoLojaRelacionado
{
    public class GetProdutoLojaRelacionadoRequest : IRequest<GetProdutoLojaRelacionadoResponse>
    {
        public Guid Id { get; set; }
        public Guid ProdutoPrincipalId { get; set; }
        public Guid ProdutoRelacionadoId { get; set; }
    }
}
