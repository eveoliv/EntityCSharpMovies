using Projeto.Filmes.App.Dados;
using Microsoft.EntityFrameworkCore;
using Projeto.Filmes.App.Extensions;
using System.Data.SqlClient;
using System.Linq;
using Microsoft.EntityFrameworkCore.Query;
using System.Collections.Generic;
using Projeto.Filmes.App.Negocio;

namespace Projeto.Filmes.App
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new FilmesContext())
            {
                context.LogSQLToConsole();

                //foreach (var item in context.Clientes)                
                //    System.Console.WriteLine(item);

                //System.Console.WriteLine();

                //foreach (var item in context.Funcionarios)                
                //    System.Console.WriteLine(item);

                //var maisAtuantes = context
                //    .Atores
                //    .Include(f => f.Filmografia)
                //    .OrderByDescending(f => f.Filmografia.Count)
                //    .Take(5);

                //var maisAtuantes = ExemploFromSql(context);
                var maisAtuantes = ExemploFromSqlComView(context);

                foreach (var item in maisAtuantes)
                {
                    System.Console.WriteLine($"{item.PrimeiroNome} {item.UltimoNome} - {item.Filmografia.Count} filmes");
                }

                //ProceduresSql(context,"delete");

                //Procedures(context);
            }
        }

        private static IIncludableQueryable<Ator, IList<FilmeAtor>> ExemploFromSql(FilmesContext context)
        {
            var sql = @"select a.*
                            from actor a
                                inner join
                            (select top 5 a.actor_id, count(*) as total
                            from actor a
                                inner join film_actor fa on fa.actor_id = a.actor_id
                            group by a.actor_id
                            order by total desc) filmes on filmes.actor_id = a.actor_id";

            var resultado = context.Atores.FromSql(sql).Include(f => f.Filmografia);
            return resultado;
        }

        private static IIncludableQueryable<Ator, IList<FilmeAtor>> ExemploFromSqlComView(FilmesContext context)
        {
            //nome da view top5_most_starred_actors

            var sql = @"select a.* from actor a
                        inner join top5_most_starred_actors filmes on filmes.actor_id = a.actor_id";

            var resultado = context.Atores.FromSql(sql).Include(f => f.Filmografia);
            return resultado;
        }

        private static void ProceduresSql(FilmesContext context, string tipo)
        {
            //Essa estrutura pode ser utilizada para delete e update passando a string no command

            var sql = string.Empty;

            if (tipo == "insert")
                sql = "INSERT INTO language (name) VALUES ('Teste 1')";

            if (tipo == "delete")
                sql = "DELETE FROM language WHERE name LIKE 'Teste%'";


            context.Database.ExecuteSqlCommand(sql);
        }

        private static void Procedures(FilmesContext context)
        {
            var categ = "Action";

            var paramCateg = new SqlParameter("category_name", categ);

            var paramTotal = new SqlParameter
            {
                ParameterName = "@total_actors",
                Size = 4,
                Direction = System.Data.ParameterDirection.Output
            };

            context.Database
                .ExecuteSqlCommand("total_actors_from_given_category @category_name, @total_actors OUT", paramCateg, paramTotal);


            System.Console.WriteLine($"O total de atores na categoria { categ } é de { paramTotal.Value }.");
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

    //comandos do sql procedure
    //declare @total int
    //execute total_actors_from_given_category 'Action', @total OUT
    //select @total
}