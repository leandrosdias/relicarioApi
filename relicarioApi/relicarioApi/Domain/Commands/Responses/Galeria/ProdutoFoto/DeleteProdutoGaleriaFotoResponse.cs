namespace relicarioApi.Domain.Commands.Responses.Galeria.ProdutoFoto
{
    public class DeleteProdutoGaleriaFotoResponse : ResponseBase
    {
        public DeleteProdutoGaleriaFotoResponse(bool sucess, string erro) : base(sucess, erro)
        {
        }

        public DeleteProdutoGaleriaFotoResponse()
        {
        }
    }
}
