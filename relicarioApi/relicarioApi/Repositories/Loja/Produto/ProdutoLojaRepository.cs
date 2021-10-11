using Microsoft.EntityFrameworkCore;
using relicarioApi.Data;
using relicarioApi.Domain.Commands.Requests.ProdutoLoja;
using relicarioApi.Models;
using System;
using System.Collections.Generic;
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

        public void Delete(DeleteProdutoLojaRequest request)
        {
            var produto = _context.LojaProdutos.FirstOrDefault(x => x.Id == request.Id);
            if (produto != null)
            {
                _context.Remove(produto);
            }
        }

        public ProdutoLoja FindByCodigo(int codigo)
        {
            return _context.LojaProdutos.FirstOrDefault(x => x.Codigo == codigo);
        }

        public ProdutoLoja FindByNome(string nome)
        {
            return _context.LojaProdutos.FirstOrDefault(x => x.Nome.ToLower() == nome.ToLower());
        }

        public ProdutoLoja Get(Guid id)
        {
            return _context.LojaProdutos.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<ProdutoLoja> Get(GetProdutoLojaRequest param)
        {
            var queryProduto = _context.LojaProdutos
                .Include(x => x.CategoriaLoja)
                .Include(x => x.ProdutoLojaAtributos)
                .Include(x => x.ProdutosRelacionados)
                .Include(x => x.Fotos).AsQueryable();

            if (param.Id != Guid.Empty)
            {
                return queryProduto.Where(x => x.Id == param.Id).ToList();
            }

            if (!string.IsNullOrWhiteSpace(param.Nome))
            {
                queryProduto = queryProduto.Where(x => x.Nome.ToLower().Contains(param.Nome.ToLower()));
            }

            if (param.CategoriaLojaId != Guid.Empty)
            {
                queryProduto = queryProduto.Where(x => x.CategoriaLojaId == param.CategoriaLojaId);
            }

            if (param.Codigos != null && param.Codigos.Count > 0)
            {
                queryProduto = queryProduto.Where(x => param.Codigos.Contains(x.Codigo));
            }

            return queryProduto.ToList();
        }

        public void Save(ProdutoLoja produto)
        {
            _context.LojaProdutos.Add(produto);
        }

        public ProdutoLoja Update(ProdutoLoja produto)
        {
            var produtoDb = _context.LojaProdutos.FirstOrDefault(x => x.Id == produto.Id);
            if (produtoDb == null)
            {
#pragma warning disable S112 // General exceptions should never be thrown
                throw new Exception(message: $"Categoria de galeria não encotrada para atualizar: {produtoDb?.Id}");
#pragma warning restore S112 // General exceptions should never be thrown
            }

            if (produto.CategoriaLojaId != Guid.Empty)
                produtoDb.CategoriaLojaId = produto.CategoriaLojaId;

            if (produto.Comprimento != 0)
                produtoDb.Comprimento = produto.Comprimento;

            if (produto.Altura != 0)
                produtoDb.Altura = produto.Altura;

            if (produto.Largura != 0)
                produtoDb.Largura = produto.Largura;

            if (produto.Estoque != 0)
                produtoDb.Estoque = produto.Estoque;

            if (produto.Codigo != 0)
                produtoDb.Codigo = produto.Codigo;

            if (!string.IsNullOrWhiteSpace(produto.Peso))
                produtoDb.Peso = produto.Peso;

            if (!string.IsNullOrWhiteSpace(produto.Nome))
                produtoDb.Nome = produto.Nome;

            if (!string.IsNullOrWhiteSpace(produto.DescricaoCurta))
                produtoDb.DescricaoCurta = produto.DescricaoCurta;

            if (!string.IsNullOrWhiteSpace(produto.DescricaoLonga))
                produtoDb.DescricaoLonga = produto.DescricaoLonga;

            if (produto.PrecoOriginal != 0)
                produtoDb.PrecoOriginal = produto.PrecoOriginal;

            if (produto.PrecoPromocional != 0)
                produtoDb.PrecoPromocional = produto.PrecoPromocional;

            SaveFotos(produto, produtoDb);
            SaveRelacionados(produto);
            SaveAtributos(produto);

            return produtoDb;
        }

        private void SaveFotos(ProdutoLoja produto, ProdutoLoja produtoDb)
        {
            foreach (var foto in produto.Fotos)
            {
                var fotoDb = _context.LojaProdutosFoto
                    .FirstOrDefault(x => x.ProdutoLojaId == produtoDb.Id && x.Sequencia == foto.Sequencia);

                if (fotoDb != null)
                {
                    fotoDb.Foto = foto.Foto;
                }
                else
                {
                    _context.LojaProdutosFoto.Add(foto);
                }
            }
        }

        private void SaveRelacionados(ProdutoLoja produto)
        {
            foreach (var produtoRelacionado in produto.ProdutosRelacionados)
            {
                var releacionadosDb = _context.LojaProdutosRelacionados
                    .Where(x => x.ProdutoPrincipalId == produto.Id);

                var relacionadoDb = releacionadosDb.FirstOrDefault(x => x.ProdutoRelacionadoId == produtoRelacionado.ProdutoRelacionadoId);
                if (relacionadoDb == null)
                {
                    _context.LojaProdutosRelacionados.Add(produtoRelacionado);
                }
            }
        }

        private void SaveAtributos(ProdutoLoja produto)
        {
            foreach (var atributo in produto.ProdutoLojaAtributos)
            {
                var atributosDb = _context.LojaProdutosAtributo.Where(x => x.ProdutoLojaId == produto.Id);
                var atributoDb = atributosDb.FirstOrDefault(x => x.Nome.ToLower() == atributo.Nome.ToLower());

                if (atributoDb == null)
                {
                    _context.LojaProdutosAtributo.Add(atributo);
                }
                else
                {
                    atributoDb.Valor = atributo.Valor;
                }
            }
        }
    }
}
