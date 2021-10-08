using relicarioApi.Models;
using System.Collections.Generic;

namespace relicarioApi.Domain.Commands.Responses.Galeria.Artistas
{
    public class GetArtistaResponse : ResponseBase
    {
        public GetArtistaResponse(bool sucess, string erro) : base(sucess, erro)
        {
        }

        public GetArtistaResponse()
        {

        }

        public GetArtistaResponse(IEnumerable<Artista> artistas)
        {
            Artistas = artistas;
        }

        public IEnumerable<Artista> Artistas { get; set; }
    }
}
