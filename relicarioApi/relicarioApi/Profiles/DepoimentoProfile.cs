using AutoMapper;
using relicarioApi.Domain.Commands.Requests.Home.Depoimento;
using relicarioApi.Domain.Commands.Responses.Home.Depoimento;
using relicarioApi.Models;

namespace relicarioApi.Profiles
{
    public class DepoimentoProfile : Profile
    {
        public DepoimentoProfile()
        {
            CreateMap<CreateDepoimentoRequest, Depoimento>();
            CreateMap<ChangeDepoimentoRequest, Depoimento>();

            CreateMap<Depoimento, CreateDepoimentoResponse>();
            CreateMap<Depoimento, ChangeDepoimentoResponse>();

        }
    }
}
