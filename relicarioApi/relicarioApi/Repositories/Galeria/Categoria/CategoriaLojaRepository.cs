using relicarioApi.Data;
using relicarioApi.Domain.Commands.Requests.CategoriaLoja;
using relicarioApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace relicarioApi.Repositories
{
    public class CategoriaLojaRepository : ICategoriaLojaRepository
    {
        private readonly DataContext _context;
        public CategoriaLojaRepository(DataContext context)
        {
            _context = context;
        }

        public void Save(CategoriaLoja categoria)
        {
            _context.LojaCategorias.Add(categoria);
        }

        public IEnumerable<CategoriaLoja> Get(GetCategoriaLojaRequest param)
        {
            var categoriasQuery = _context.LojaCategorias.AsQueryable();

            if (param.Id != Guid.Empty)
            {
                categoriasQuery = categoriasQuery.Where(x => x.Id == param.Id);
                return categoriasQuery.ToList();
            }

            if (param.CodigoPai != 0)
            {
                categoriasQuery = categoriasQuery.Where(x => x.CodigoPai == param.CodigoPai);
            }

            if (!string.IsNullOrWhiteSpace(param.Nome))
            {
                categoriasQuery = categoriasQuery.Where(x => x.Nome.ToLower().Contains(param.Nome.ToLower()));
            }

            if (param.BarraSuperior != null)
            {
                categoriasQuery = categoriasQuery.Where(x => x.BarraSuperior == param.BarraSuperior);
            }

            if (param.Codigos != null && param.Codigos.Count > 0)
            {
                categoriasQuery = categoriasQuery.Where(x => param.Codigos.Contains(x.Codigo));
            }

            return categoriasQuery.ToList();
        }

        public void Delete(DeleteCategoriaLojaRequest request)
        {
            var categoria = _context.LojaCategorias.FirstOrDefault(x => x.Id == request.Id);

            if (categoria != null)
            {
                _context.LojaCategorias.Remove(categoria);
            }
        }

        public CategoriaLoja Update(CategoriaLoja categoriaLoja)
        {
            var categoriaDb = _context.LojaCategorias.FirstOrDefault(x => x.Id == categoriaLoja.Id);
            if (categoriaDb == null)
            {
#pragma warning disable S112 // General exceptions should never be thrown
                throw new Exception(message: $"Categoria de loja não encotrado para atualizar: {categoriaDb?.Id}");
#pragma warning restore S112 // General exceptions should never be thrown
            }

            categoriaDb.BarraSuperior = categoriaLoja.BarraSuperior;
            categoriaDb.Codigo = categoriaLoja.Codigo;
            categoriaDb.CodigoPai = categoriaLoja.CodigoPai;
            categoriaDb.Nome = categoriaLoja.Nome;

            return categoriaDb;
        }

        public CategoriaLoja FindByCodigo(int codigo)
        {
            return _context.LojaCategorias.FirstOrDefault(x => x.Codigo == codigo);
        }
    }
}
