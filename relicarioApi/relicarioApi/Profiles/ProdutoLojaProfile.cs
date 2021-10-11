using AutoMapper;
using relicarioApi.Domain.Commands.Requests.ProdutoLoja;
using relicarioApi.Domain.Commands.Responses.ProdutoLoja;
using relicarioApi.Models;

namespace relicarioApi.Profiles
{
    public class ProdutoLojaProfile : Profile
    {
        public ProdutoLojaProfile()
        {
            CreateMap<CreateProdutoLojaRequest, ProdutoLoja>();
            CreateMap<ChangeProdutoLojaRequest, ProdutoLoja>();

            CreateMap<ProdutoLoja, CreateProdutoLojaResponse>();
            CreateMap<ProdutoLoja, ChangeProdutoLojaResponse>();
        }
    }
}
