using MediatR;
using relicarioApi.Domain.Commands.Responses.Galeria.Categorias;
using System;
using System.Collections.Generic;

namespace relicarioApi.Domain.Commands.Requests.Galeria.Categorias
{
    public class GetCategoriaGaleriaRequest : IRequest<GetCategoriaGaleriaResponse>
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public List<string> Codigos { get; set; }
        public int CodigoPai { get; set; }
    }
}
