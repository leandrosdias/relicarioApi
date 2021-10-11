using AutoMapper;
using relicarioApi.Domain.Commands.Requests.Galeria.ProdutoFoto;
using relicarioApi.Domain.Commands.Responses.Galeria.ProdutoFoto;
using relicarioApi.Models;

namespace relicarioApi.Profiles
{
    public class GaleriaProdutoFotoProfile : Profile
    {
        public GaleriaProdutoFotoProfile()
        {
            CreateMap<CreateProdutoGaleriaFotoRequest, ProdutoGaleriaFoto>();
            CreateMap<ChangeProdutoGaleriaFotoRequest, ProdutoGaleriaFoto>();

            CreateMap<ProdutoGaleriaFoto, CreateProdutoGaleriaFotoResponse>();
            CreateMap<ProdutoGaleriaFoto, ChangeProdutoGaleriaFotoResponse>();
        }
    }
}
