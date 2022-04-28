using MediatR;
using relicarioApi.Domain.Commands.Requests.ProdutoLojaAtributo;
using relicarioApi.Domain.Commands.Responses.Loja.ProdutoAtributos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace relicarioApi.Domain.Commands.Requests.Loja.ProdutoAtributo
{
    public class ChangeListProdutoAtributoRequest : IRequest<ChangeListProdutoAtributoResponse>
    {
        public Guid ProdutoLojaId { get; set; }
        public List<CreateProdutoLojaAtributoRequest> Produtos { get; set; }
    }
}
