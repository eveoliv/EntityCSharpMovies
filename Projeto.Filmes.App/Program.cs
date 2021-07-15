using Projeto.Filmes.App.Dados;
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

                foreach (var item in context.Filmes)
                {
                    System.Console.WriteLine($"Ator {item.Id} {item.Titulo} {item.AnoLancamento}");
                }
            }
        }
    }
}