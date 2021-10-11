using System;

namespace relicarioApi.Domain.Commands.Responses.ProdutoLojaRelacionado
{
    public class ChangeProdutoLojaRelacionadoResponse : ResponseBase
    {
        public ChangeProdutoLojaRelacionadoResponse(bool sucess, string erro) : base(sucess, erro)
        {
        }

        public ChangeProdutoLojaRelacionadoResponse()
        {

        }

        public Models.ProdutoLoja ProdutoPrincipal { get; set; }
        public Guid ProdutoPrincipalId { get; set; }
        public Models.ProdutoLoja ProdutoRelacionado { get; set; }
        public Guid ProdutoRelacionadoId { get; set; }

    }
}
