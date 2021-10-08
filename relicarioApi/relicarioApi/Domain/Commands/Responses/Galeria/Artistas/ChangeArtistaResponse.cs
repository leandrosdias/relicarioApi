using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace relicarioApi.Domain.Commands.Responses.Galeria.Artistas
{
    public class ChangeArtistaResponse : ResponseBase
    {
        public ChangeArtistaResponse(bool sucess, string erro) : base(sucess, erro)
        {
        }

        public ChangeArtistaResponse()
        {

        }

        public string Nome { get; set; }
        public string DescricaoLonga { get; set; }
        public string DescricaoCurta { get; set; }
    }
}
