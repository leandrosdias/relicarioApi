using relicarioApi.Domain.Commands.Requests.Galeria.Artistas;
using relicarioApi.Models;
using System.Collections.Generic;

namespace relicarioApi.Repositories.Galeria.Artistas
{
    public interface IArtistaRepository
    {
        void Save(Artista artista);
        IEnumerable<Artista> Get(GetArtistaRequest param);
        void Delete(DeleteArtistaRequest request);
        Artista Update(Artista artista);
        Artista FindByNome(string nome);
    }
}
