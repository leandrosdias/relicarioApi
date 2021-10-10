using relicarioApi.Domain.Commands.Requests.CategoriaLoja;
using relicarioApi.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace relicarioApi.Repositories
{
    public interface ICategoriaLojaRepository
    {
        void Save(CategoriaLoja categoria);
        IEnumerable<CategoriaLoja> Get(GetCategoriaLojaRequest param);
        void Delete(DeleteCategoriaLojaRequest request);
        CategoriaLoja Update(CategoriaLoja categoriaLoja);
        CategoriaLoja FindByCodigo(int codigo);
    }
}
