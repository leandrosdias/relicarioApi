using relicarioApi.Models;
using System;

namespace relicarioApi.Repositories
{
    public interface IProdutoLojaRepository
    {
        public void Save(ProdutoLoja produto);
        public ProdutoLoja Get(Guid id);
    }
}
