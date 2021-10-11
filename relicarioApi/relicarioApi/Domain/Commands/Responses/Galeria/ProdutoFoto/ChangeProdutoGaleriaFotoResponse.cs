using relicarioApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace relicarioApi.Domain.Commands.Responses.Galeria.ProdutoFoto
{
    public class ChangeProdutoGaleriaFotoResponse : ResponseBase 
    {
        public ChangeProdutoGaleriaFotoResponse(bool sucess, string erro) : base(sucess, erro)
        {
        }

        public ChangeProdutoGaleriaFotoResponse()
        {

        }

        public int Sequencia { get; set; }
        public byte[] Foto { get; set; }
        public Guid ProdutoGategoriaId { get; set; }
    }
}
