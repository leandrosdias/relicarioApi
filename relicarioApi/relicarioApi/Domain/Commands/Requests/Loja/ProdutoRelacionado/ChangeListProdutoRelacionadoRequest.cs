using MediatR;
using relicarioApi.Domain.Commands.Requests.ProdutoLojaRelacionado;
using relicarioApi.Domain.Commands.Responses.Loja.ProdutoRelacionado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace relicarioApi.Domain.Commands.Requests.Loja.ProdutoRelacionado
{
    public class ChangeListProdutoRelacionadoRequest : IRequest<ChangeListProdutoRelacionadoResponse>
    {
        public Guid ProdutoLojaId { get; set; }
        public List<CreateProdutoLojaRelacionadoRequest> ProdutosRelacionados { get; set; }
    }
}
