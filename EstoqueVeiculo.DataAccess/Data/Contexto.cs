using EstoqueVeiculo.Models;
using Microsoft.EntityFrameworkCore;

namespace EstoqueVeiculo.DataAccess.Data
{
    public class Contexto : DbContext
    {

        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        public DbSet<Produto> Produto { get; set; }
        public DbSet<Categoria> Categoria { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Categoria>()
                .HasData(new
                {
                    Id = 1,
                    Nome = "Informática"
                });
            builder.Entity<Categoria>()
                .HasData(new
                {
                    Id = 2,
                    Nome = "Móveis"
                });
            builder.Entity<Categoria>()
                .HasData(new
                {
                    Id = 3,
                    Nome = "Moda"
                });
        }
    }
}
