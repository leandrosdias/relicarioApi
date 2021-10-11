namespace relicarioApi.Domain.Commands.Responses.Loja.ProdutoFoto
{
    public class DeleteProdutoLojaFotoResponse : ResponseBase
    {
        public DeleteProdutoLojaFotoResponse(bool sucess, string erro) : base(sucess, erro)
        {
        }

        public DeleteProdutoLojaFotoResponse()
        {
        }
    }
}
