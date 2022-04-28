using MediatR;
using relicarioApi.Domain.Commands.Responses.Home.Depoimento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace relicarioApi.Domain.Commands.Requests.Home.Depoimento
{
    public class GetDepoimentoRequest : IRequest<GetDepoimentoResponse>
    {
        public Guid Id { get; internal set; }
    }
}
