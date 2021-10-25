namespace relicarioApi.Domain.Commands.Responses.Home.Numeros
{
    public class ChangeNumerosResponse : ResponseBase
    {
        public ChangeNumerosResponse(bool sucess, string erro) : base(sucess, erro)
        {
        }

        public ChangeNumerosResponse()
        {

        }

        public int Numero { get; set; }
        public string Descricao { get; set; }
    }
}
