namespace relicarioApi.Domain.Commands.Responses.Galeria.Categorias
{
    public class DeleteCategoriaGaleriaResponse : ResponseBase
    {
        public DeleteCategoriaGaleriaResponse(bool sucess, string erro) : base(sucess, erro)
        {
        }

        public DeleteCategoriaGaleriaResponse()
        {
        }
    }
}
