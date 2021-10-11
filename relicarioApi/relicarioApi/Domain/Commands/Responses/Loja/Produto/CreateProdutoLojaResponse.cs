using System;

namespace relicarioApi.Domain.Commands.Responses.ProdutoLoja
{
    public class CreateProdutoLojaResponse : ResponseBase
    {
        public CreateProdutoLojaResponse(bool sucess, string erro) : base(sucess, erro)
        {
        }

        public CreateProdutoLojaResponse()
        {

        }

        public Guid Id { get; set; }
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
