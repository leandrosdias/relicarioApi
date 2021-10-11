namespace relicarioApi.Domain.Commands.Responses.Galeria.Produtos
{
    public class DeleteGaleriaProdutoResponse : ResponseBase
    {
        public DeleteGaleriaProdutoResponse(bool sucess, string erro) : base(sucess, erro)
        {
        }

        public DeleteGaleriaProdutoResponse()
        {
        }
    }
}
