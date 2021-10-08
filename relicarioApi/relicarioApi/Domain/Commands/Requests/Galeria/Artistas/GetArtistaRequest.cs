using MediatR;
using relicarioApi.Domain.Commands.Responses.Galeria.Artistas;
using System;

namespace relicarioApi.Domain.Commands.Requests.Galeria.Artistas
{
    public class GetArtistaRequest : IRequest<GetArtistaResponse>
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }

    }
}
