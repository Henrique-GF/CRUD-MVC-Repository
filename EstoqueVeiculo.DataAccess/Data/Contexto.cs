using EstoqueVeiculo.Models;
using Microsoft.EntityFrameworkCore;

namespace EstoqueVeiculo.DataAccess.Data
{
    public class Contexto : DbContext
    {

        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        public DbSet<Veiculo> Veiculo { get; set; }
        public DbSet<TipoVeiculo> TipoVeiculo { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<TipoVeiculo>()
                .HasData(new
                {
                    Id = 1,
                    Nome = "Carro"
                });
            builder.Entity<TipoVeiculo>()
                .HasData(new
                {
                    Id = 2,
                    Nome = "Moto"
                });
            builder.Entity<TipoVeiculo>()
                .HasData(new
                {
                    Id = 3,
                    Nome = "Caminhão"
                });

        }
    }
}
