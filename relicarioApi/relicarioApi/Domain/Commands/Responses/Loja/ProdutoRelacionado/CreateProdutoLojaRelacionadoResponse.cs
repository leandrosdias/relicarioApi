using System;

namespace relicarioApi.Domain.Commands.Responses.ProdutoLojaRelacionado
{
    public class CreateProdutoLojaRelacionadoResponse : ResponseBase
    {
        public CreateProdutoLojaRelacionadoResponse(bool sucess, string erro) : base(sucess, erro)
        {
        }

        public CreateProdutoLojaRelacionadoResponse()
        {

        }

        public Guid Id { get; set; }
        public Models.ProdutoLoja ProdutoPrincipal { get; set; }
        public Guid ProdutoPrincipalId { get; set; }
        public Models.ProdutoLoja ProdutoRelacionado { get; set; }
        public Guid ProdutoRelacionadoId { get; set; }
    }
}
