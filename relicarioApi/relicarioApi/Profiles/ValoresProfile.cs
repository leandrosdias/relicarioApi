using AutoMapper;
using relicarioApi.Domain.Commands.Requests.Home.Valores;
using relicarioApi.Domain.Commands.Responses.Home.Valores;
using relicarioApi.Models;

namespace relicarioApi.Profiles
{
    public class ValoresProfile : Profile
    {
        public ValoresProfile()
        {
            CreateMap<CreateValoresRequest, Valores>();
            CreateMap<ChangeValoresRequest, Valores>();

            CreateMap<Valores, CreateValoresResponse>();
            CreateMap<Valores, ChangeValoresResponse>();

        }
    }
}
