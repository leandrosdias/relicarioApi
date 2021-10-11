using Microsoft.EntityFrameworkCore;
using relicarioApi.Data;
using relicarioApi.Domain.Commands.Requests.ProdutoLoja;
using relicarioApi.Domain.Commands.Requests.ProdutoLojaRelacionado;
using relicarioApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace relicarioApi.Repositories
{
    public class ProdutoLojaRelacionadoRepository : IProdutoLojaRelacionadoRepository
    {
        private readonly DataContext _context;
        public ProdutoLojaRelacionadoRepository(DataContext context)
        {
            _context = context;
        }

        public void Delete(DeleteProdutoLojaRelacionadoRequest request)
        {
            var produto = _context.LojaProdutosRelacionados.FirstOrDefault(x => x.Id == request.Id);
            if (produto != null)
            {
                _context.Remove(produto);
            }
        }

        public IEnumerable<ProdutoLojaRelacionado> Get(GetProdutoLojaRelacionadoRequest param)
        {
            if (param.Id != Guid.Empty)
            {
                return _context.LojaProdutosRelacionados.Where(x => x.Id == param.Id);
            }

            
            if (param.ProdutoRelacionadoId != Guid.Empty)
            {
                return _context.LojaProdutosRelacionados.Where(x => x.ProdutoRelacionadoId == param.ProdutoRelacionadoId);
            }

            return _context.LojaProdutosRelacionados;
        }

        public void Save(ProdutoLojaRelacionado produtoRelacionado)
        {
            _context.LojaProdutosRelacionados.Add(produtoRelacionado);
        }

        public ProdutoLojaRelacionado Update(ProdutoLojaRelacionado produtoRelacionado)
        {
            var produtoRelacionadoDb = _context.LojaProdutosRelacionados.FirstOrDefault(x => x.Id == produtoRelacionado.Id);
            if (produtoRelacionadoDb == null)
            {
#pragma warning disable S112 // General exceptions should never be thrown
                throw new Exception(message: $"Categoria de galeria não encotrada para atualizar: {produtoRelacionadoDb?.Id}");
#pragma warning restore S112 // General exceptions should never be thrown
            }

            produtoRelacionadoDb.ProdutoRelacionadoId = produtoRelacionado.ProdutoRelacionadoId;
            return produtoRelacionadoDb;
        }
    }
}
