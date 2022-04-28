using relicarioApi.Domain.Commands.Requests.Galeria.ProdutoFoto;
using relicarioApi.Models;
using System;
using System.Collections.Generic;

namespace relicarioApi.Repositories.Galeria.Produtos
{
    public interface IProdutoGaleriaFotoRepository
    {
        ProdutoGaleriaFoto Update(ProdutoGaleriaFoto produtoGaleriaFoto);
        void Save(ProdutoGaleriaFoto produto);
        IEnumerable<ProdutoGaleriaFoto> Get(GetProdutoGaleriaFotoRequest param);
        void Delete(DeleteProdutoGaleriaFotoRequest request);
        void Delete(Guid id);
    }
}
