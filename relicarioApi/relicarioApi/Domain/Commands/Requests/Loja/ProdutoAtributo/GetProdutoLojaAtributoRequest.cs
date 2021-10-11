using MediatR;
using relicarioApi.Domain.Commands.Responses.ProdutoLojaAtributo;
using System;
using System.Collections.Generic;

namespace relicarioApi.Domain.Commands.Requests.ProdutoLojaAtributo
{
    public class GetProdutoLojaAtributoRequest : IRequest<GetProdutoLojaAtributoResponse>
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public Guid ProdutoLojaId { get; set; }
    }
}
