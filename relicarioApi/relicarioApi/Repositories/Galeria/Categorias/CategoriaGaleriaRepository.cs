using relicarioApi.Data;
using relicarioApi.Domain.Commands.Requests.Galeria.Categorias;
using relicarioApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace relicarioApi.Repositories.Galeria.Categorias
{
    public class CategoriaGaleriaRepository : ICategoriaGaleriaRepository
    {
        private readonly DataContext _dataContext;

        public CategoriaGaleriaRepository(DataContext datacontext)
        {
            _dataContext = datacontext;
        }

        public void Delete(DeleteCategoriaGaleriaRequest request)
        {
            var categoria = _dataContext.GaleriaCategorias.FirstOrDefault(x => x.Id == request.Id);
            if (categoria != null)
            {
                _dataContext.Remove(categoria);
            }
        }

        public CategoriaGaleria FindByCodigo(string codigo)
        {
            return _dataContext.GaleriaCategorias.FirstOrDefault(x => x.Codigo == codigo);
        }

        public CategoriaGaleria FindByNome(string nome)
        {
            return _dataContext.GaleriaCategorias.FirstOrDefault(x => x.Nome.ToLower() == nome.ToLower());
        }

        public IEnumerable<CategoriaGaleria> Get(GetCategoriaGaleriaRequest param)
        {
            var queryCat = _dataContext.GaleriaCategorias.AsQueryable();

            if (param.Id != Guid.Empty)
            {
                return queryCat.Where(x => x.Id == param.Id);
            }

            if (!string.IsNullOrWhiteSpace(param.Nome))
            {
                queryCat = queryCat.Where(x => x.Nome.ToLower().Contains(param.Nome.ToLower()));
            }

            if (param.CodigoPai != 0)
            {
                queryCat = queryCat.Where(x => x.CategoriaPai == param.CodigoPai);
            }

            if (param.Codigos != null && param.Codigos.Count > 0)
            {
                queryCat = queryCat.Where(x => param.Codigos.Contains(x.Codigo));
            }

            return queryCat.OrderBy(x => x.Codigo).AsEnumerable();
        }

        public void Save(CategoriaGaleria categoria)
        {
            _dataContext.GaleriaCategorias.Add(categoria);
        }

        public CategoriaGaleria Update(CategoriaGaleria categoria)
        {
            var categoriaDb = _dataContext.GaleriaCategorias.FirstOrDefault(x => x.Id == categoria.Id);
            if (categoriaDb == null)
            {
#pragma warning disable S112 // General exceptions should never be thrown
                throw new Exception(message: $"Categoria de galeria não encotrada para atualizar: {categoriaDb?.Id}");
#pragma warning restore S112 // General exceptions should never be thrown
            }

            categoriaDb.CategoriaPai = categoria.CategoriaPai;
            categoriaDb.Codigo = categoria.Codigo;
            categoriaDb.Nome = categoria.Nome;

            return categoriaDb;
        }
    }
}
