using Microsoft.EntityFrameworkCore;
using relicarioApi.Models;

namespace relicarioApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> opt) : base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoriaLoja>().HasIndex(cat => cat.Codigo).IsUnique();

            modelBuilder.Entity<CategoriaGaleria>().HasIndex(cat => cat.Codigo).IsUnique();

            modelBuilder.Entity<ProdutoLojaRelacionado>()
                .HasOne(relacionado => relacionado.ProdutoPrincipal)
                .WithMany(produtoPrincipal => produtoPrincipal.ProdutosRelacionados)
                .HasForeignKey(relacionado => relacionado.ProdutoPrincipalId);

            modelBuilder.Entity<ProdutoLojaRelacionado>().HasOne(relacionado => relacionado.ProdutoRelacionado);

            modelBuilder.Entity<Artista>().HasIndex(art => art.Nome).IsUnique();
        }

        public DbSet<CategoriaLoja> LojaCategorias { get; set; }
        public DbSet<ProdutoLoja> LojaProdutos { get; set; }
        public DbSet<CategoriaGaleria> GaleriaCategorias { get; set; }
        public DbSet<ProdutoGaleria> GaleriaProdutos { get; set; }
        public DbSet<User> Usuarios { get; set; }
        public DbSet<Artista> Artistas { get; set; }
    }
}
