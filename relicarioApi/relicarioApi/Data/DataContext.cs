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

            modelBuilder.Entity<ProdutoGaleria>().HasOne(x => x.Artista).WithMany(x => x.Produtos).HasForeignKey(x => x.ArtistaId);
            modelBuilder.Entity<ProdutoGaleria>().HasOne(x => x.CategoriaGaleria).WithMany(x => x.Produtos).HasForeignKey(x => x.CategoriaGaleriaId);
            modelBuilder.Entity<ProdutoGaleria>().Property(x => x.ProdutoLojaId).IsRequired(false);
            modelBuilder.Entity<ProdutoGaleria>().HasIndex(x => x.Nome).IsUnique();
            modelBuilder.Entity<ProdutoGaleria>().HasIndex(x => x.Codigo).IsUnique();
        }

        public DbSet<CategoriaLoja> LojaCategorias { get; set; }
        public DbSet<ProdutoLoja> LojaProdutos { get; set; }
        public DbSet<CategoriaGaleria> GaleriaCategorias { get; set; }
        public DbSet<ProdutoGaleria> GaleriaProdutos { get; set; }
        public DbSet<User> Usuarios { get; set; }
        public DbSet<Artista> Artistas { get; set; }
    }
}
