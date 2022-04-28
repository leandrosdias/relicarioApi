using AutoMapper;
using relicarioApi.Domain.Commands.Requests.System.Parameter;
using relicarioApi.Domain.Commands.Responses.System.Parameter;
using relicarioApi.Models;

namespace relicarioApi.Profiles
{
    public class ParametersProfile : Profile
    {
        public ParametersProfile()
        {
            CreateMap<CreateParametersRequest, Parameters>();
            CreateMap<ChangeParametersRequest, Parameters>();

            CreateMap<Parameters, CreateParametersResponse>();
            CreateMap<Parameters, ChangeParametersResponse>();

        }
    }
}
