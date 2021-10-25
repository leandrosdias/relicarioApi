using MediatR;
using relicarioApi.Domain.Commands.Responses.CategoriaLoja;
using System;
using System.Collections.Generic;

namespace relicarioApi.Domain.Commands.Requests.CategoriaLoja
{
    public class GetCategoriaLojaRequest : IRequest<GetCategoriaLojaResponse>
    {
        public Guid Id { get; set; }
        public List<string> Codigos { get; set; }
        public int CodigoPai { get; set; }
        public string Nome { get; set; }
        public bool? BarraSuperior { get; set; }
    }
}
