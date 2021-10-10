using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace relicarioApi.Domain.Commands.Responses.Galeria.Categorias
{
    public class ChangeCategoriaGaleriaResponse : ResponseBase
    {
        public ChangeCategoriaGaleriaResponse(bool sucess, string erro) : base(sucess, erro)
        {
        }

        public ChangeCategoriaGaleriaResponse()
        {

        }

        public int Codigo { get; set; }
        public string Nome { get; set; }
        public int CategoriaPai { get; set; }
    }
}
