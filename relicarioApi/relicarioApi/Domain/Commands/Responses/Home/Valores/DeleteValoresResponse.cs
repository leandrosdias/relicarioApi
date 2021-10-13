namespace relicarioApi.Domain.Commands.Responses.Home.Valores
{
    public class DeleteValoresResponse : ResponseBase
    {
        public DeleteValoresResponse(bool sucess, string erro) : base(sucess, erro)
        {
        }

        public DeleteValoresResponse()
        {
        }
    }
}
