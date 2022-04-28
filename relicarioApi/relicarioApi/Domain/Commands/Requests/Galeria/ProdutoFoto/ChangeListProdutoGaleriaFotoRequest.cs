using MediatR;
using relicarioApi.Domain.Commands.Responses.Galeria.ProdutoFoto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace relicarioApi.Domain.Commands.Requests.Galeria.ProdutoFoto
{
    public class ChangeListProdutoGaleriaFotoRequest : IRequest<ChangeListProdutoGaleriaFotoResponse>
    {
        public Guid ProdutoLojaId { get; set; }
        public List<CreateProdutoGaleriaFotoRequest> Produtos { get; set; }
    }
}
