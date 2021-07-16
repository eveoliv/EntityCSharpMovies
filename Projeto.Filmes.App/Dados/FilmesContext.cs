using Projeto.Filmes.App.Negocio;
using Microsoft.EntityFrameworkCore;

namespace Projeto.Filmes.App.Dados
{
    public class FilmesContext : DbContext
    {
        public DbSet<Ator> Atores { get; set; }
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Idioma> Idiomas { get; set; }
        public DbSet<FilmeAtor> Elenco { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1401;Database=ProjetoFilmes;User Id=sa;Password=Root@root!");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AtorConfiguration());

            modelBuilder.ApplyConfiguration(new FilmeConfiguration());

            modelBuilder.ApplyConfiguration(new FilmeAtorConfiguration());    

            modelBuilder.ApplyConfiguration(new IdiomaConfiguration());    
            
        }
    }
}
