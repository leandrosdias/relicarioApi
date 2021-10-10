using relicarioApi.Data;
using relicarioApi.Domain.Commands.Requests.Galeria.Artistas;
using relicarioApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace relicarioApi.Repositories.Galeria.Artistas
{
    public class ArtistaRepository : IArtistaRepository
    {
        private readonly DataContext _context;

        public ArtistaRepository(DataContext context)
        {
            _context = context;
        }

        public void Delete(DeleteArtistaRequest request)
        {
            var artista = _context.Artistas.FirstOrDefault(x => x.Id == request.Id);

            if (artista != null)
            {
                _context.Artistas.Remove(artista);
            }
        }

        public Artista FindByNome(string nome)
        {
            return _context.Artistas.FirstOrDefault(x => x.Nome.ToLower() == nome.ToLower());
        }

        public IEnumerable<Artista> Get(GetArtistaRequest param)
        {
            var artistasQuery = _context.Artistas.AsQueryable();

            if (param.Id != Guid.Empty)
            {
                return artistasQuery.Where(x => x.Id == param.Id);
            }

            if (!string.IsNullOrWhiteSpace(param.Nome))
            {
                artistasQuery = artistasQuery.Where(x => x.Nome.ToLower().Contains(param.Nome.ToLower()));
            }

            return artistasQuery.AsEnumerable();
        }

        public void Save(Artista artista)
        {
            _context.Artistas.Add(artista);
        }

        public Artista Update(Artista artista)
        {
            var artistaDb = _context.Artistas.FirstOrDefault(x => x.Id == artista.Id);
            if (artistaDb == null)
            {
#pragma warning disable S112 // General exceptions should never be thrown
                throw new Exception(message: $"Artista não encotrado para atualizar: {artistaDb?.Id}");
#pragma warning restore S112 // General exceptions should never be thrown
            }

            artistaDb.DescricaoCurta = artista.DescricaoCurta;
            artistaDb.DescricaoLonga = artista.DescricaoLonga;
            artistaDb.Nome = artista.Nome;

            return artistaDb;
        }
    }
}
