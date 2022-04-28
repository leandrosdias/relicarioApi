using AutoMapper;
using relicarioApi.Domain.Commands.Requests.Loja.ProdutoFoto;
using relicarioApi.Domain.Commands.Responses.Loja.ProdutoFoto;
using relicarioApi.Models;

namespace relicarioApi.Profiles
{
    public class ProdutoLojaFotoProfile : Profile
    {
        public ProdutoLojaFotoProfile()
        {
            CreateMap<CreateProdutoLojaFotoRequest, ProdutoLojaFoto>();
            CreateMap<ChangeProdutoLojaFotoRequest, ProdutoLojaFoto>();

            CreateMap<ProdutoLojaFoto, CreateProdutoLojaFotoResponse>();
            CreateMap<ProdutoLojaFoto, ChangeProdutoLojaFotoResponse>();
        }
    }
}
