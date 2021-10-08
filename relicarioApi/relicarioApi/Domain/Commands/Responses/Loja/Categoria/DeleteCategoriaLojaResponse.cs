namespace relicarioApi.Domain.Commands.Responses.CategoriaLoja
{
    public class DeleteCategoriaLojaResponse : ResponseBase
    {
        public DeleteCategoriaLojaResponse(bool sucess, string erro) : base(sucess, erro)
        {
        }

        public DeleteCategoriaLojaResponse()
        {
        }
    }
}
