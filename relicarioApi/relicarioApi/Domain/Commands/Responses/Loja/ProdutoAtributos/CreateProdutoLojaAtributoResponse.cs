using System;

namespace relicarioApi.Domain.Commands.Responses.ProdutoLojaAtributo
{
    public class CreateProdutoLojaAtributoResponse : ResponseBase
    {
        public CreateProdutoLojaAtributoResponse(bool sucess, string erro) : base(sucess, erro)
        {
        }

        public CreateProdutoLojaAtributoResponse()
        {

        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Valor { get; set; }
        public Models.ProdutoLoja ProdutoLoja { get; set; }
        public Guid ProdutoLojaId { get; set; }
    }
}
