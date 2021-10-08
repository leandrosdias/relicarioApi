using AutoMapper;
using relicarioApi.Domain.Commands.Requests.CategoriaLoja;
using relicarioApi.Domain.Commands.Responses.CategoriaLoja;
using relicarioApi.Models;

namespace relicarioApi.Profiles
{
    public class CategoriaLojaProfile : Profile
    {
        public CategoriaLojaProfile()
        {
            CreateMap<CreateCategoriaLojaRequest, CategoriaLoja>();
            CreateMap<ChangeCategoriaLojaRequest, CategoriaLoja>();

            CreateMap<CategoriaLoja, CreateCategoriaLojaResponse>();
            CreateMap<CategoriaLoja, ChangeCategoriaLojaResponse>();
        }
    }
}
