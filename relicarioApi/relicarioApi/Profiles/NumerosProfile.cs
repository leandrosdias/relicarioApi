using AutoMapper;
using relicarioApi.Domain.Commands.Requests.Home.Numeros;
using relicarioApi.Domain.Commands.Responses.Home.Numeros;
using relicarioApi.Models;

namespace relicarioApi.Profiles
{
    public class NumerosProfile : Profile
    {
        public NumerosProfile()
        {
            CreateMap<CreateNumerosRequest, Numeros>();
            CreateMap<ChangeNumerosRequest, Numeros>();

            CreateMap<Numeros, CreateNumerosResponse>();
            CreateMap<Numeros, ChangeNumerosResponse>();

        }
    }
}
