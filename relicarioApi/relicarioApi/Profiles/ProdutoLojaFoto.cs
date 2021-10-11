using AutoMapper;
using relicarioApi.Domain.Commands.Requests.Loja.ProdutoFoto;
using relicarioApi.Domain.Commands.Responses.Loja.ProdutoFoto;

namespace relicarioApi.Profiles
{
    public class ProdutoLojaFoto : Profile
    {
        public ProdutoLojaFoto()
        {
            CreateMap<CreateProdutoLojaFotoRequest, ProdutoLojaFoto>();
            CreateMap<ChangeProdutoLojaFotoRequest, ProdutoLojaFoto>();

            CreateMap<ProdutoLojaFoto, CreateProdutoLojaFotoResponse>();
            CreateMap<ProdutoLojaFoto, ChangeProdutoLojaFotoResponse>();
        }
    }
}
