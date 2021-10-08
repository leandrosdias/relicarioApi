using MediatR;
using relicarioApi.Domain.Commands.Responses.Galeria.Artistas;
using System;

namespace relicarioApi.Domain.Commands.Requests.Galeria.Artistas
{
    public class DeleteArtistaRequest : IRequest<DeleteArtistaResponse>
    {
        public Guid Id { get; set; }

    }
}
