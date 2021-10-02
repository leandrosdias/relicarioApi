using Microsoft.EntityFrameworkCore;
using relicarioApi.Models;

namespace relicarioApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> opt) : base(opt)
        {

        }

        public DbSet<CategoriaLoja> LojaCategorias { get; set; }
        public DbSet<ProdutoLoja> LojaProdutos { get; set; }
        public DbSet<CategoriaGaleria> GaleriaCategorias { get; set; }
        public DbSet<ProdutoGaleria> GaleriaProdutos { get; set; }
        public DbSet<User> Usuarios { get; set; }
        public DbSet<Artista> Artistas { get; set; }
    }
}
