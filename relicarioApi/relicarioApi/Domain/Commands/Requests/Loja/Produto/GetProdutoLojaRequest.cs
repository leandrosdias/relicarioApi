using MediatR;
using relicarioApi.Domain.Commands.Responses.ProdutoLoja;
using System;
using System.Collections.Generic;

namespace relicarioApi.Domain.Commands.Requests.ProdutoLoja
{
    public class GetProdutoLojaRequest : IRequest<GetProdutoLojaResponse>
    {
        public Guid Id { get; set; }
        public List<int> Codigos { get; set; }
        public Guid CategoriaLojaId { get; set; }
        public string Nome { get; set; }
    }
}
