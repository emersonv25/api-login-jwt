using Login.Models;
using Microsoft.EntityFrameworkCore;

namespace Login.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options)
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().HasKey(u => u.Id);
            modelBuilder.Entity<Usuario>().Property(u => u.Username).HasMaxLength(64).IsRequired();
            modelBuilder.Entity<Usuario>().HasIndex(u => u.Username).IsUnique(true);
            modelBuilder.Entity<Usuario>().HasIndex(u => u.Email).IsUnique(true);
            modelBuilder.Entity<Usuario>().Property(u => u.Password).HasMaxLength(128).IsRequired();
            modelBuilder.Entity<Usuario>().Property(u => u.Ativo).HasMaxLength(2).HasDefaultValue(1).IsRequired();
            modelBuilder.Entity<Usuario>().Property(u => u.Cargo).HasDefaultValue("usuario").IsRequired();
            modelBuilder.Entity<Usuario>().Property(u => u.Email).HasMaxLength(256).IsRequired();
            modelBuilder.Entity<Usuario>()
                .HasData(
                    new Usuario { Id = 1, Username = "admin", Nome = "Administrador", Password = "admin", Ativo = 1, Cargo = "admin" ,Email = "admin@admin.com" }
                );
        }
    }
}