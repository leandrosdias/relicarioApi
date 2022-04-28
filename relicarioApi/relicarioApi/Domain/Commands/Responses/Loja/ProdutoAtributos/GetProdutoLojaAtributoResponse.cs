using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace relicarioApi.Domain.Commands.Responses.ProdutoLojaAtributo
{
    public class GetProdutoLojaAtributoResponse : ResponseBase
    {

        public GetProdutoLojaAtributoResponse(bool sucess, string erro) : base(sucess, erro)
        {
        }

        public GetProdutoLojaAtributoResponse()
        {

        }

        public GetProdutoLojaAtributoResponse(IEnumerable<Models.ProdutoLojaAtributo> atributos, bool distinct)
        {
            if (!distinct)
            {
                Atributos = atributos;
            }
            else
            {
                AtributoNameList = atributos.Select(x => x.Nome).Distinct();
            }
        }

        public IEnumerable<Models.ProdutoLojaAtributo> Atributos { get; set; }
        public IEnumerable<string> AtributoNameList { get; set; }
    }
}
