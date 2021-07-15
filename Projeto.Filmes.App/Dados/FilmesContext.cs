using System;
using Microsoft.EntityFrameworkCore;
using Projeto.Filmes.App.Negocio;

namespace Projeto.Filmes.App.Dados
{
    public class FilmesContext : DbContext
    {
        public DbSet<Ator> Atores { get; set; }
        public DbSet<Filme> Filmes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1401;Database=ProjetoFilmes;User Id=sa;Password=Root@root!");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AtorConfiguration());

            modelBuilder.ApplyConfiguration(new FilmeConfiguration());            
        }
    }
}
