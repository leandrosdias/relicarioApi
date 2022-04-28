using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace relicarioApi.Domain.Commands.Responses.ProdutoLoja
{
    public class GetProdutoLojaResponse : ResponseBase
    {

        public GetProdutoLojaResponse(bool sucess, string erro) : base(sucess, erro)
        {
        }

        public GetProdutoLojaResponse()
        {

        }

        public GetProdutoLojaResponse(IEnumerable<Models.ProdutoLoja> produtos, bool getNames)
        {
            if (!getNames)
            {
                Produtos = produtos;
            }
            else
            {
                ProdutoNames = produtos.Select(x => new { Id = x.Id, Name = x.Codigo + " - " + x.Nome });
            };
        }

        public IEnumerable<Models.ProdutoLoja> Produtos { get; set; }
        public IEnumerable<object> ProdutoNames { get; set; }
    }
}
