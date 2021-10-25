namespace relicarioApi.Domain.Commands.Responses.Home.Numeros
{
    public class DeleteNumerosResponse : ResponseBase
    {
        public DeleteNumerosResponse(bool sucess, string erro) : base(sucess, erro)
        {
        }

        public DeleteNumerosResponse()
        {
        }
    }
}
