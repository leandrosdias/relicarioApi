namespace relicarioApi.Domain.Commands.Responses.ProdutoLoja
{
    public class DeleteProdutoLojaResponse : ResponseBase
    {
        public DeleteProdutoLojaResponse(bool sucess, string erro) : base(sucess, erro)
        {
        }

        public DeleteProdutoLojaResponse()
        {
        }
    }
}
