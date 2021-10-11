using AutoMapper;
using relicarioApi.Domain.Commands.Requests.ProdutoLojaAtributo;
using relicarioApi.Domain.Commands.Responses.ProdutoLojaAtributo;
using relicarioApi.Models;

namespace relicarioApi.Profiles
{
    public class ProdutoLojaAtributoProfile : Profile
    {
        public ProdutoLojaAtributoProfile()
        {
            CreateMap<CreateProdutoLojaAtributoRequest, ProdutoLojaAtributo>();
            CreateMap<ChangeProdutoLojaAtributoRequest, ProdutoLojaAtributo>();

            CreateMap<ProdutoLojaAtributo, CreateProdutoLojaAtributoResponse>();
            CreateMap<ProdutoLojaAtributo, ChangeProdutoLojaAtributoResponse>();
        }
    }
}
