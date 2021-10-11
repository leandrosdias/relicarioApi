using relicarioApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace relicarioApi.Domain.Commands.Responses.Galeria.Produtos
{
    public class ChangeGaleriaProdutoResponse : ResponseBase 
    {
        public ChangeGaleriaProdutoResponse(bool sucess, string erro) : base(sucess, erro)
        {
        }

        public ChangeGaleriaProdutoResponse()
        {

        }

        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string DescricaoCurta { get; set; }
        public string DescricaoLonga { get; set; }
        public Artista Artista { get; set; }
        public Guid ArtistaId { get; set; }
        public CategoriaGaleria CategoriaGaleria { get; set; }
        public Guid CategoriaGaleriaId { get; set; }
        public IEnumerable<ProdutoGaleriaFoto> Fotos { get; set; }
        public Guid ProdutoLojaId { get; set; }
        public ProdutoLoja ProdutoLoja { get; set; }
    }
}
