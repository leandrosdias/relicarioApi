namespace relicarioApi.Domain.Commands.Responses.ProdutoLojaAtributo
{
    public class DeleteProdutoLojaAtributoResponse : ResponseBase
    {
        public DeleteProdutoLojaAtributoResponse(bool sucess, string erro) : base(sucess, erro)
        {
        }

        public DeleteProdutoLojaAtributoResponse()
        {
        }
    }
}
