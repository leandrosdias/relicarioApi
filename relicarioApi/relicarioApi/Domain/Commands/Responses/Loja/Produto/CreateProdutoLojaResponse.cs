using System;

namespace relicarioApi.Domain.Commands.Responses
{
    public class CreateProdutoLojaResponse : ResponseBase
    {
        public CreateProdutoLojaResponse(bool sucess, string error) : base(sucess, error)
        {
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public decimal PrecoPromocional { get; set; }
        public DateTime CreatedTs { get; set; }

    }
}
