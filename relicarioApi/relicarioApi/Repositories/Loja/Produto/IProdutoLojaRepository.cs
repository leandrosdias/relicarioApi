using relicarioApi.Domain.Commands.Requests.ProdutoLoja;
using relicarioApi.Models;
using System;
using System.Collections.Generic;

namespace relicarioApi.Repositories
{
    public interface IProdutoLojaRepository
    {
        public void Save(ProdutoLoja produto);
        public ProdutoLoja Get(Guid id);
        IEnumerable<ProdutoLoja> Get(GetProdutoLojaRequest param);
        ProdutoLoja FindByCodigo(string codigo);
        ProdutoLoja Update(ProdutoLoja produto);
        void Delete(DeleteProdutoLojaRequest request);
        ProdutoLoja FindByNome(string nome);
    }
}
