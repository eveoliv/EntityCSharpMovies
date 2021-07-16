using System.Linq;
using Projeto.Filmes.App.Dados;
using Microsoft.EntityFrameworkCore;
using Projeto.Filmes.App.Extensions;

namespace Projeto.Filmes.App
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new FilmesContext())
            {
                context.LogSQLToConsole();

                var idiomas = context.Idiomas.Include(f => f.FilmesFalados);

                foreach (var item in idiomas)
                {
                    System.Console.WriteLine(item);
                }
            }
        }

        private static void Imprime(FilmesContext context, Negocio.FilmeAtor item)
        {
            var entidade = context.Entry(item);
            var filmId = entidade.Property("film_id").CurrentValue;
            var atorId = entidade.Property("actor_id").CurrentValue;
            var lasUpd = entidade.Property("last_update").CurrentValue;

            System.Console.WriteLine($"Filme {filmId} Ator {atorId} LastUpdate {lasUpd}");
        }
    }
}