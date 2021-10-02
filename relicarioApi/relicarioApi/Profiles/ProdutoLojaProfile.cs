using AutoMapper;
using relicarioApi.Domain.Commands.Requests;
using relicarioApi.Domain.Commands.Responses;
using relicarioApi.Models;

namespace relicarioApi.Profiles
{
    public class ProdutoLojaProfile : Profile
    {
        public ProdutoLojaProfile()
        {
            CreateMap<CreateProdutoLojaRequest, ProdutoLoja>();
            CreateMap<ProdutoLoja, CreateProdutoLojaResponse>();
        }
    }
}
