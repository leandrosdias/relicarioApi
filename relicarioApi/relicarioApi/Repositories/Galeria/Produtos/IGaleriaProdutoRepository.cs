using relicarioApi.Domain.Commands.Requests.Galeria.Produtos;
using relicarioApi.Models;
using System.Collections.Generic;

namespace relicarioApi.Repositories.Galeria.Produtos
{
    public interface IGaleriaProdutoRepository
    {
        ProdutoGaleria FindByCodigo(int codigo);
        ProdutoGaleria Update(ProdutoGaleria galeriaProduto);
        void Save(ProdutoGaleria produto);
        IEnumerable<ProdutoGaleria> Get(GetGaleriaProdutoRequest param);
        void Delete(DeleteGaleriaProdutoRequest request);
        ProdutoGaleria FindByNome(string nome);
    }
}
