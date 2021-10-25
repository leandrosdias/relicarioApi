namespace relicarioApi.Domain.Commands.Responses.System.Parameter
{
    public class DeleteParametersResponse : ResponseBase
    {
        public DeleteParametersResponse(bool sucess, string erro) : base(sucess, erro)
        {
        }

        public DeleteParametersResponse()
        {
        }
    }
}
