using System;

namespace relicarioApi.Domain.Commands.Responses.ProdutoLoja
{
    public class ChangeProdutoLojaResponse : ResponseBase
    {
        public ChangeProdutoLojaResponse(bool sucess, string erro) : base(sucess, erro)
        {
        }

        public ChangeProdutoLojaResponse()
        {

        }

        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string DescricaoCurta { get; set; }
        public string DescricaoLonga { get; set; }
        public decimal PrecoOriginal { get; set; }
        public decimal PrecoPromocional { get; set; }
        public int Estoque { get; set; }
        public string Peso { get; set; }
        public decimal Comprimento { get; set; }
        public decimal Altura { get; set; }
        public decimal Largura { get; set; }
        public Guid CategoriaLojaId { get; set; }

    }
}
