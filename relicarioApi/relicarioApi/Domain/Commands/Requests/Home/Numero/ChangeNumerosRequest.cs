using MediatR;
using relicarioApi.Domain.Commands.Responses.Home.Numeros;
using System;
using System.ComponentModel.DataAnnotations;

namespace relicarioApi.Domain.Commands.Requests.Home.Numeros
{
    public class ChangeNumerosRequest : IRequest<ChangeNumerosResponse>
    {
        public Guid Id { get; set; }
        public int Numero { get; set; }
        public string Descricao { get; set; }

    }
}
