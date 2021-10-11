using relicarioApi.Domain.Commands.Requests.ProdutoLojaRelacionado;
using relicarioApi.Models;
using System.Collections.Generic;

namespace relicarioApi.Repositories
{
    public interface IProdutoLojaRelacionadoRepository
    {
        public void Save(ProdutoLojaRelacionado produtoRelacionado);
        IEnumerable<ProdutoLojaRelacionado> Get(GetProdutoLojaRelacionadoRequest param);
        ProdutoLojaRelacionado Update(ProdutoLojaRelacionado produtoRelacionado);
        void Delete(DeleteProdutoLojaRelacionadoRequest request);
    }
}
