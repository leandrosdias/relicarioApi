using Microsoft.EntityFrameworkCore;
using relicarioApi.Data;
using relicarioApi.Domain.Commands.Requests.Galeria.ProdutoFoto;
using relicarioApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace relicarioApi.Repositories.Galeria.Produtos
{
    public class ProdutoGaleriaFotoRepository : IProdutoGaleriaFotoRepository
    {
        private readonly DataContext _context;

        public ProdutoGaleriaFotoRepository(DataContext datacontext)
        {
            _context = datacontext;
        }

        public void Delete(DeleteProdutoGaleriaFotoRequest request)
        {
            var produto = _context.ProdutoGaleriaFotos.FirstOrDefault(x => x.Id == request.Id);
            if (produto != null)
            {
                _context.Remove(produto);
            }
        }

        public void Delete(Guid id)
        {
            var produto = _context.ProdutoGaleriaFotos.FirstOrDefault(x => x.Id == id);
            if (produto != null)
            {
                _context.Remove(produto);
            }
        }

        public IEnumerable<ProdutoGaleriaFoto> Get(GetProdutoGaleriaFotoRequest param)
        {
            var queryProduto = _context.ProdutoGaleriaFotos.AsQueryable();

            if (param.Id != Guid.Empty)
            {
                return queryProduto.Where(x => x.Id == param.Id);
            }

            if (param.ProdutoGaleriaId != Guid.Empty)
            {
                return queryProduto.Where(x => x.ProdutoGaleriaId == param.ProdutoGaleriaId);
            }

            return queryProduto.ToList();
        }

        public void Save(ProdutoGaleriaFoto produto)
        {
            _context.ProdutoGaleriaFotos.Add(produto);
        }

        public ProdutoGaleriaFoto Update(ProdutoGaleriaFoto produtoGaleriaFoto)
        {
            var produtoDb = _context.ProdutoGaleriaFotos.FirstOrDefault(x => x.Id == produtoGaleriaFoto.Id);
            if (produtoDb == null)
            {
#pragma warning disable S112 // General exceptions should never be thrown
                throw new Exception(message: $"Categoria de galeria não encotrada para atualizar: {produtoDb?.Id}");
#pragma warning restore S112 // General exceptions should never be thrown
            }

            produtoDb.Foto = produtoGaleriaFoto.Foto;
            produtoDb.ProdutoGaleriaId = produtoGaleriaFoto.ProdutoGaleriaId;
            produtoDb.Sequencia = produtoGaleriaFoto.Sequencia;

            return produtoDb;
        }
    }
}
