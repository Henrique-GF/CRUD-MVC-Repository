using EstoqueProdutos.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EstoqueProdutos.DataAccess.Data
{
    public class Contexto : IdentityDbContext<IdentityUser>
    {

        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        public DbSet<Produto> Produto { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    builder.Entity<Categoria>()
        //        .HasData(new
        //        {
        //            Id = 1,
        //            Nome = "Informática"
        //        });
        //    builder.Entity<Categoria>()
        //        .HasData(new
        //        {
        //            Id = 2,
        //            Nome = "Móveis"
        //        });
        //    builder.Entity<Categoria>()
        //        .HasData(new
        //        {
        //            Id = 3,
        //            Nome = "Moda"
        //        });
        //    builder.Entity<Usuario>()
        //        .HasData(new
        //        {
        //            Id = 1,
        //            Nome = "admin",
        //            Senha = "admin"
        //        });
        //}
    }
}
