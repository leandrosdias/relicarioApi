using System;

namespace relicarioApi.Domain.Commands.Responses.ProdutoLojaAtributo
{
    public class ChangeProdutoLojaAtributoResponse : ResponseBase
    {
        public ChangeProdutoLojaAtributoResponse(bool sucess, string erro) : base(sucess, erro)
        {
        }

        public ChangeProdutoLojaAtributoResponse()
        {

        }

        public string Nome { get; set; }
        public string Valor { get; set; }
        public Models.ProdutoLoja ProdutoLoja { get; set; }
        public Guid ProdutoLojaId { get; set; }

    }
}
