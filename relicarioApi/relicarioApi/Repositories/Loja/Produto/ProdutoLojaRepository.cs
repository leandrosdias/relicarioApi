using relicarioApi.Data;
using relicarioApi.Models;
using System;
using System.Linq;

namespace relicarioApi.Repositories
{
    public class ProdutoLojaRepository : IProdutoLojaRepository
    {
        private readonly DataContext _context;
        public ProdutoLojaRepository(DataContext context)
        {
            _context = context;
        }

        public ProdutoLoja Get(Guid id)
        {
            return _context.LojaProdutos.FirstOrDefault(x => x.Id == id);
        }

        public void Save(ProdutoLoja produto)
        {
            _context.LojaProdutos.Add(produto);
        }
    }
}
