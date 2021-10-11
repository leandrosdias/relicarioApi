using relicarioApi.Domain.Commands.Requests.ProdutoLojaAtributo;
using relicarioApi.Models;
using System.Collections.Generic;

namespace relicarioApi.Repositories
{
    public interface IProdutoLojaAtributoRepository
    {
        public void Save(ProdutoLojaAtributo produtoAtributo);
        IEnumerable<ProdutoLojaAtributo> Get(GetProdutoLojaAtributoRequest param);
        ProdutoLojaAtributo Update(ProdutoLojaAtributo produtoAtributo);
        void Delete(DeleteProdutoLojaAtributoRequest request);
    }
}
