using MediatR;
using relicarioApi.Domain.Commands.Responses.CategoriaLoja;
using System;

namespace relicarioApi.Domain.Commands.Requests.CategoriaLoja
{
    public class DeleteCategoriaLojaRequest : IRequest<DeleteCategoriaLojaResponse>
    {
        public Guid Id { get; set; }
    }
}
