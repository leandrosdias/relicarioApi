using MediatR;
using relicarioApi.Domain.Commands.Responses.Galeria.Produtos;
using System;
using System.Collections.Generic;

namespace relicarioApi.Domain.Commands.Requests.Galeria.Produtos
{
    public class GetGaleriaProdutoRequest : IRequest<GetGaleriaProdutoResponse>
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public List<int> Codigos { get; set; }
        public Guid ArtistaId { get; set; }
        public Guid CategoriaGaleriaId { get; set; }
        public Guid ProdutoLojaId { get; set; }
    }
}