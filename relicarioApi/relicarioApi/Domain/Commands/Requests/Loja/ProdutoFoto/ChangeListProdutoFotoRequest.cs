using MediatR;
using relicarioApi.Domain.Commands.Responses.Loja.ProdutoFoto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace relicarioApi.Domain.Commands.Requests.Loja.ProdutoFoto
{
    public class ChangeListProdutoFotoRequest : IRequest<ChangeListProdutoFotoResponse>
    {
        public Guid ProdutoLojaId { get; set; }
        public List<CreateProdutoLojaFotoRequest> Produtos { get; set; }
    }
}
