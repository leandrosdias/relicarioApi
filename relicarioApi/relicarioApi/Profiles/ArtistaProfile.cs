using AutoMapper;
using relicarioApi.Domain.Commands.Requests.Galeria.Artistas;
using relicarioApi.Domain.Commands.Responses.Galeria.Artistas;
using relicarioApi.Models;

namespace relicarioApi.Profiles
{
    public class ArtistaProfile : Profile
    {
        public ArtistaProfile()
        {
            CreateMap<CreateArtistaRequest, Artista>();
            CreateMap<ChangeArtistaRequest, Artista>();

            CreateMap<Artista, CreateArtistaResponse>();
            CreateMap<Artista, ChangeArtistaResponse>();

        }
    }
}
