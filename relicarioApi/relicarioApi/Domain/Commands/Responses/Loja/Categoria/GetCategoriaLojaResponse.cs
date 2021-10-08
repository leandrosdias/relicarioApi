using System.Collections.Generic;
using System.Threading.Tasks;

namespace relicarioApi.Domain.Commands.Responses.CategoriaLoja
{
    public class GetCategoriaLojaResponse : ResponseBase
    {

        public GetCategoriaLojaResponse(bool sucess, string erro) : base(sucess, erro)
        {
        }

        public GetCategoriaLojaResponse()
        {

        }

        public GetCategoriaLojaResponse(IEnumerable<Models.CategoriaLoja> categorias)
        {
            Categorias = categorias;
        }
        
        public IEnumerable<Models.CategoriaLoja> Categorias { get; set; }
    }
}
