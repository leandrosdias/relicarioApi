using relicarioApi.Models;
using System;
using System.Collections.Generic;

namespace relicarioApi.Domain.Commands.Responses.Galeria.ProdutoFoto
{
    public class CreateProdutoGaleriaFotoResponse : ResponseBase
    {
        public CreateProdutoGaleriaFotoResponse(bool sucess, string erro) : base(sucess, erro)
        {
        }

        public CreateProdutoGaleriaFotoResponse()
        {

        }

        public Guid Id { get; set; }
        public int Sequencia { get; set; }
        public byte[] Foto { get; set; }
        public Guid ProdutoGategoriaId { get; set; }
    }
}
