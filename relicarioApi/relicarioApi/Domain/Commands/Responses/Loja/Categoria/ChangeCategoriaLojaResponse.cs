namespace relicarioApi.Domain.Commands.Responses.CategoriaLoja
{
    public class ChangeCategoriaLojaResponse : ResponseBase
    {
        public ChangeCategoriaLojaResponse(bool sucess, string erro) : base(sucess, erro)
        {
        }

        public ChangeCategoriaLojaResponse()
        {

        }

        public int Codigo { get; set; }
        public string Nome { get; set; }
        public int CodigoPai { get; set; }
        public bool BarraSuperior { get; set; }

    }
}
