using relicarioApi.Domain.Commands.Requests.Loja.ProdutoFoto;
using relicarioApi.Models;
using System;
using System.Collections.Generic;

namespace relicarioApi.Repositories.Loja.Produtos
{
    public interface IProdutoLojaFotoRepository
    {
        ProdutoLojaFoto Update(ProdutoLojaFoto produtoLojaFoto);
        void Save(ProdutoLojaFoto produto);
        IEnumerable<ProdutoLojaFoto> Get(GetProdutoLojaFotoRequest param);
        void Delete(DeleteProdutoLojaFotoRequest request);
        void Delete(Guid id);
        void SaveOrUpdate(ProdutoLojaFoto produtoLojaFoto);
    }
}
