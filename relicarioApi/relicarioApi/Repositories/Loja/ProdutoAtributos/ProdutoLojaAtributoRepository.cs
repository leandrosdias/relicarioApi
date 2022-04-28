using Microsoft.EntityFrameworkCore;
using relicarioApi.Data;
using relicarioApi.Domain.Commands.Requests.ProdutoLoja;
using relicarioApi.Domain.Commands.Requests.ProdutoLojaAtributo;
using relicarioApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace relicarioApi.Repositories
{
    public class ProdutoLojaAtributoRepository : IProdutoLojaAtributoRepository
    {
        private readonly DataContext _context;
        public ProdutoLojaAtributoRepository(DataContext context)
        {
            _context = context;
        }

        public void Delete(DeleteProdutoLojaAtributoRequest request)
        {
            var produto = _context.LojaProdutosAtributo.FirstOrDefault(x => x.Id == request.Id);
            if (produto != null)
            {
                _context.Remove(produto);
            }
        }

        public void Delete(Guid id)
        {
            var produto = _context.LojaProdutosAtributo.FirstOrDefault(x => x.Id == id);
            if (produto != null)
            {
                _context.Remove(produto);
            }
        }

        public IEnumerable<ProdutoLojaAtributo> Get(GetProdutoLojaAtributoRequest param)
        {
            if (param.Id != Guid.Empty)
            {
                return _context.LojaProdutosAtributo.Where(x => x.Id == param.Id);
            }

            var query = _context.LojaProdutosAtributo.AsQueryable();

            if (!string.IsNullOrWhiteSpace(param.Nome))
            {
                query = query.Where(x => x.Nome.ToLower().Contains(param.Nome.ToLower()));
            }

            if (param.ProdutoLojaId != Guid.Empty)
            {
                query = query.Where(x => x.ProdutoLojaId == param.ProdutoLojaId);
            }

            return query.ToList();
        }

        public void Save(ProdutoLojaAtributo produtoAtributo)
        {
            _context.LojaProdutosAtributo.Add(produtoAtributo);
        }

        public ProdutoLojaAtributo Update(ProdutoLojaAtributo produtoAtributo)
        {
            var produtoAtributoDb = _context.LojaProdutosAtributo.FirstOrDefault(x => x.Id == produtoAtributo.Id);
            if (produtoAtributoDb == null)
            {
#pragma warning disable S112 // General exceptions should never be thrown
                throw new Exception(message: $"Categoria de galeria não encotrada para atualizar: {produtoAtributoDb?.Id}");
#pragma warning restore S112 // General exceptions should never be thrown
            }

            produtoAtributoDb.Nome = produtoAtributo.Nome;
            produtoAtributoDb.Valor = produtoAtributo.Valor;
            produtoAtributoDb.ProdutoLojaId = produtoAtributo.ProdutoLojaId;

            return produtoAtributoDb;
        }
    }
}
