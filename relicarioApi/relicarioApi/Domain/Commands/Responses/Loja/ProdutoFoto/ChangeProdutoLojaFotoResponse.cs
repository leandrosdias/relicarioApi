using relicarioApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace relicarioApi.Domain.Commands.Responses.Loja.ProdutoFoto
{
    public class ChangeProdutoLojaFotoResponse : ResponseBase 
    {
        public ChangeProdutoLojaFotoResponse(bool sucess, string erro) : base(sucess, erro)
        {
        }

        public ChangeProdutoLojaFotoResponse()
        {

        }

        public int Sequencia { get; set; }
        public byte[] Foto { get; set; }
        public Guid ProdutoLojaId { get; set; }
    }
}
