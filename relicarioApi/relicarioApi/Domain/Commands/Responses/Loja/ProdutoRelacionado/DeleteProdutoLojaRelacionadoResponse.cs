namespace relicarioApi.Domain.Commands.Responses.ProdutoLojaRelacionado
{
    public class DeleteProdutoLojaRelacionadoResponse : ResponseBase
    {
        public DeleteProdutoLojaRelacionadoResponse(bool sucess, string erro) : base(sucess, erro)
        {
        }

        public DeleteProdutoLojaRelacionadoResponse()
        {
        }
    }
}
