using AutoMapper;
using relicarioApi.Domain.Commands.Requests.ProdutoLojaRelacionado;
using relicarioApi.Domain.Commands.Responses.ProdutoLojaRelacionado;
using relicarioApi.Models;

namespace relicarioApi.Profiles
{
    public class ProdutoLojaRelacionadoProfile : Profile
    {
        public ProdutoLojaRelacionadoProfile()
        {
            CreateMap<CreateProdutoLojaRelacionadoRequest, ProdutoLojaRelacionado>();
            CreateMap<ChangeProdutoLojaRelacionadoRequest, ProdutoLojaRelacionado>();

            CreateMap<ProdutoLojaRelacionado, CreateProdutoLojaRelacionadoResponse>();
            CreateMap<ProdutoLojaRelacionado, ChangeProdutoLojaRelacionadoResponse>();
        }
    }
}
