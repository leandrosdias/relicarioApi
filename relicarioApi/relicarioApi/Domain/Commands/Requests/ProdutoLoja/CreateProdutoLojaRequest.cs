using MediatR;
using relicarioApi.Domain.Commands.Responses;

namespace relicarioApi.Domain.Commands.Requests
{
    public class CreateProdutoLojaRequest : IRequest<CreateProdutoLojaResponse>
    {
        public string Nome { get; set; }
        public decimal PrecoPromocional { get; set; }
    }
}
