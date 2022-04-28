using Microsoft.EntityFrameworkCore;
using relicarioApi.Data;
using relicarioApi.Domain.Commands.Requests.Loja.ProdutoFoto;
using relicarioApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace relicarioApi.Repositories.Loja.Produtos
{
    public class ProdutoLojaFotoRepository : IProdutoLojaFotoRepository
    {
        private readonly DataContext _context;

        public ProdutoLojaFotoRepository(DataContext datacontext)
        {
            _context = datacontext;
        }

        public void Delete(DeleteProdutoLojaFotoRequest request)
        {
            var produto = _context.LojaProdutosFoto.FirstOrDefault(x => x.Id == request.Id);
            if (produto != null)
            {
                _context.Remove(produto);
            }
        }

        public void Delete(Guid id)
        {
            var produto = _context.LojaProdutosFoto.FirstOrDefault(x => x.Id == id);
            if (produto != null)
            {
                _context.Remove(produto);
            }
        }

        public IEnumerable<ProdutoLojaFoto> Get(GetProdutoLojaFotoRequest param)
        {
            var queryProduto = _context.LojaProdutosFoto.AsQueryable();

            if (param.Id != Guid.Empty)
            {
                return queryProduto.Where(x => x.Id == param.Id);
            }

            if (param.ProdutoLojaId != Guid.Empty)
            {
                return queryProduto.Where(x => x.ProdutoLojaId == param.ProdutoLojaId);
            }

            return queryProduto.ToList();
        }

        public void Save(ProdutoLojaFoto produto)
        {
            _context.LojaProdutosFoto.Add(produto);
        }

        public void SaveOrUpdate(ProdutoLojaFoto produtoLojaFoto)
        {
            var prod = _context.LojaProdutosFoto.FirstOrDefault(x => x.Id == produtoLojaFoto.Id);
            if (prod == null)
            {
                Save(produtoLojaFoto);
            }
            else
            {
                Update(produtoLojaFoto);
            }
        }

        public ProdutoLojaFoto Update(ProdutoLojaFoto produtoLojaFoto)
        {
            var produtoDb = _context.LojaProdutosFoto.FirstOrDefault(x => x.Id == produtoLojaFoto.Id);
            if (produtoDb == null)
            {
#pragma warning disable S112 // General exceptions should never be thrown
                throw new Exception(message: $"Categoria de Loja não encotrada para atualizar: {produtoDb?.Id}");
#pragma warning restore S112 // General exceptions should never be thrown
            }

            produtoDb.Foto = produtoLojaFoto.Foto;
            produtoDb.ProdutoLojaId = produtoLojaFoto.ProdutoLojaId;
            produtoDb.Sequencia = produtoLojaFoto.Sequencia;

            return produtoDb;
        }
    }
}
