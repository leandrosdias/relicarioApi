using AutoMapper;
using relicarioApi.Domain.Commands.Requests.Galeria.Produtos;
using relicarioApi.Domain.Commands.Responses.Galeria.Produtos;
using relicarioApi.Models;

namespace relicarioApi.Profiles
{
    public class GaleriaProdutoProfile : Profile
    {
        public GaleriaProdutoProfile()
        {
            CreateMap<CreateGaleriaProdutoRequest, ProdutoGaleria>();
            CreateMap<ChangeGaleriaProdutoRequest, ProdutoGaleria>();

            CreateMap<ProdutoGaleria, CreateGaleriaProdutoResponse>();
            CreateMap<ProdutoGaleria, ChangeGaleriaProdutoResponse>();
        }
    }
}
