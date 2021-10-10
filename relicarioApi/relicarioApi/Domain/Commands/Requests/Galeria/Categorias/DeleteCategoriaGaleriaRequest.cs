using MediatR;
using relicarioApi.Domain.Commands.Responses.Galeria.Categorias;
using System;

namespace relicarioApi.Domain.Commands.Requests.Galeria.Categorias
{
    public class DeleteCategoriaGaleriaRequest : IRequest<DeleteCategoriaGaleriaResponse>
    {
        public Guid Id { get; set; }
    }
}
