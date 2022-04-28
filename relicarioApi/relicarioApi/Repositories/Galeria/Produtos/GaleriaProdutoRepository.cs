using Microsoft.EntityFrameworkCore;
using relicarioApi.Data;
using relicarioApi.Domain.Commands.Requests.Galeria.Produtos;
using relicarioApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace relicarioApi.Repositories.Galeria.Produtos
{
    public class GaleriaProdutoRepository : IGaleriaProdutoRepository
    {
        private readonly DataContext _context;

        public GaleriaProdutoRepository(DataContext datacontext)
        {
            _context = datacontext;
        }

        public void Delete(DeleteGaleriaProdutoRequest request)
        {
            var produto = _context.GaleriaProdutos.FirstOrDefault(x => x.Id == request.Id);
            if (produto != null)
            {
                _context.Remove(produto);
            }
        }

        public ProdutoGaleria FindByCodigo(string codigo)
        {
            return _context.GaleriaProdutos.FirstOrDefault(x => x.Codigo == codigo);
        }

        public ProdutoGaleria FindByNome(string nome)
        {
            return _context.GaleriaProdutos.FirstOrDefault(x => x.Nome.ToLower() == nome.ToLower());
        }

        public IEnumerable<ProdutoGaleria> Get(GetGaleriaProdutoRequest param)
        {
            var queryProduto = _context.GaleriaProdutos
                .Include(x => x.Artista).Include(x => x.CategoriaGaleria).Include(x => x.Fotos).AsQueryable();

            if (param.Id != Guid.Empty)
            {
                return queryProduto.Where(x => x.Id == param.Id);
            }

            if (!string.IsNullOrWhiteSpace(param.Nome))
            {
                queryProduto = queryProduto.Where(x => x.Nome.ToLower().Contains(param.Nome.ToLower()));
            }

            if (param.ArtistaId != Guid.Empty)
            {
                queryProduto = queryProduto.Where(x => x.ArtistaId == param.ArtistaId);
            }

            if (param.CategoriaGaleriaId != Guid.Empty)
            {
                queryProduto = queryProduto.Where(x => x.CategoriaGaleriaId == param.CategoriaGaleriaId);
            }

            if (param.ProdutoLojaId != Guid.Empty)
            {
                queryProduto = queryProduto.Where(x => x.ProdutoLojaId == param.ProdutoLojaId);
            }

            if (param.Codigos != null && param.Codigos.Count > 0)
            {
                queryProduto = queryProduto.Where(x => param.Codigos.Contains(x.Codigo));
            }

            return queryProduto.ToList();
        }

        public void Save(ProdutoGaleria produto)
        {
            _context.GaleriaProdutos.Add(produto);
        }

        public ProdutoGaleria Update(ProdutoGaleria galeriaProduto)
        {
            var produtoDb = _context.GaleriaProdutos.FirstOrDefault(x => x.Id == galeriaProduto.Id);
            if (produtoDb == null)
            {
#pragma warning disable S112 // General exceptions should never be thrown
                throw new Exception(message: $"Categoria de galeria não encotrada para atualizar: {produtoDb?.Id}");
#pragma warning restore S112 // General exceptions should never be thrown
            }

            if (galeriaProduto.ArtistaId != Guid.Empty)
                produtoDb.ArtistaId = galeriaProduto.ArtistaId;

            if (galeriaProduto.CategoriaGaleriaId != Guid.Empty)
                produtoDb.CategoriaGaleriaId = galeriaProduto.CategoriaGaleriaId;

            if (galeriaProduto.ProdutoLojaId != Guid.Empty)
            {
                produtoDb.ProdutoLojaId = galeriaProduto.ProdutoLojaId;
                produtoDb.ProdutoLojaNome = galeriaProduto.ProdutoLojaNome;
            }
            else
            {
                produtoDb.ProdutoLojaNome = string.Empty;
            }

            if (!string.IsNullOrWhiteSpace(galeriaProduto.Codigo))
                produtoDb.Codigo = galeriaProduto.Codigo;

            if (!string.IsNullOrWhiteSpace(galeriaProduto.Nome))
                produtoDb.Nome = galeriaProduto.Nome;

            if (!string.IsNullOrWhiteSpace(galeriaProduto.DescricaoCurta))
                produtoDb.DescricaoCurta = galeriaProduto.DescricaoCurta;

            if (!string.IsNullOrWhiteSpace(galeriaProduto.DescricaoLonga))
                produtoDb.DescricaoLonga = galeriaProduto.DescricaoLonga;

            foreach (var foto in galeriaProduto.Fotos)
            {
                var fotoDb = _context.ProdutoGaleriaFotos
                    .FirstOrDefault(x => x.ProdutoGaleriaId == produtoDb.Id && x.Sequencia == foto.Sequencia);

                if (fotoDb != null)
                {
                    fotoDb.Foto = foto.Foto;
                }
                else
                {
                    _context.ProdutoGaleriaFotos.Add(foto);
                }
            }

            return produtoDb;
        }
    }
}
