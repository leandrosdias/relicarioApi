using relicarioApi.Models;
using System.Collections.Generic;

namespace relicarioApi.Domain.Commands.Responses.Galeria.Categorias
{
    public class GetCategoriaGaleriaResponse : ResponseBase
    {
        public GetCategoriaGaleriaResponse(bool sucess, string erro) : base(sucess, erro)
        {
        }

        public GetCategoriaGaleriaResponse()
        {

        }

        public GetCategoriaGaleriaResponse(IEnumerable<CategoriaGaleria> categoriasGaleria)
        {
            CategoriasGaleria = categoriasGaleria;
        }

        public IEnumerable<CategoriaGaleria> CategoriasGaleria { get; set; }
    }
}
