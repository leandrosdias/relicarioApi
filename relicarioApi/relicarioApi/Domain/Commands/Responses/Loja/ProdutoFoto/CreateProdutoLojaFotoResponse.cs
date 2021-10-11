using relicarioApi.Models;
using System;
using System.Collections.Generic;

namespace relicarioApi.Domain.Commands.Responses.Loja.ProdutoFoto
{
    public class CreateProdutoLojaFotoResponse : ResponseBase
    {
        public CreateProdutoLojaFotoResponse(bool sucess, string erro) : base(sucess, erro)
        {
        }

        public CreateProdutoLojaFotoResponse()
        {

        }

        public Guid Id { get; set; }
        public int Sequencia { get; set; }
        public byte[] Foto { get; set; }
        public Guid ProdutoLojaId { get; set; }
    }
}
