using System;

namespace relicarioApi.Domain.Commands.Responses
{
    public class CreateProdutoLojaResponse : ResponseBase
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public decimal PrecoPromocional { get; set; }
        public DateTime CreatedTs { get; set; }

    }
}
