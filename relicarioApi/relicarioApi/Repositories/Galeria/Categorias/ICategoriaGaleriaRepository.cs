using relicarioApi.Domain.Commands.Requests.Galeria.Categorias;
using relicarioApi.Models;
using System.Collections.Generic;

namespace relicarioApi.Repositories.Galeria.Categorias
{
    public interface ICategoriaGaleriaRepository
    {
        void Save(CategoriaGaleria categoria);
        IEnumerable<CategoriaGaleria> Get(GetCategoriaGaleriaRequest param);
        void Delete(DeleteCategoriaGaleriaRequest request);
        CategoriaGaleria Update(CategoriaGaleria categoria);
        CategoriaGaleria FindByNome(string nome);
        CategoriaGaleria FindByCodigo(int codigo);
    }
}
