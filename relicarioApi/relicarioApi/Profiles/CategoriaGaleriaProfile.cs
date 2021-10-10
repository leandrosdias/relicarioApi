using AutoMapper;
using relicarioApi.Domain.Commands.Requests.Galeria.Categorias;
using relicarioApi.Domain.Commands.Responses.Galeria.Categorias;
using relicarioApi.Models;

namespace relicarioApi.Profiles
{
    public class CategoriaGaleriaProfile : Profile
    {
        public CategoriaGaleriaProfile()
        {
            CreateMap<CreateCategoriaGaleriaRequest, CategoriaGaleria>();
            CreateMap<ChangeCategoriaGaleriaRequest, CategoriaGaleria>();

            CreateMap<CategoriaGaleria, CreateCategoriaGaleriaResponse>();
            CreateMap<CategoriaGaleria, ChangeCategoriaGaleriaResponse>();
        }
    }
}
