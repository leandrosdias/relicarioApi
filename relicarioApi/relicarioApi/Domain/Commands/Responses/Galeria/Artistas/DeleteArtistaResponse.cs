namespace relicarioApi.Domain.Commands.Responses.Galeria.Artistas
{
    public class DeleteArtistaResponse : ResponseBase
    {
        public DeleteArtistaResponse(bool sucess, string erro) : base(sucess, erro)
        {
        }

        public DeleteArtistaResponse()
        {
        }
    }
}
