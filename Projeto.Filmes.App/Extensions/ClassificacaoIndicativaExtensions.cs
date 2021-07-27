using System.Linq;
using Projeto.Filmes.App.Negocio;
using System.Collections.Generic;

namespace Projeto.Filmes.App.Extensions
{
    public static class ClassificacaoIndicativaExtensions
    {
        private static Dictionary<string, ClassificacaoIndicativa> MapaClassificacao()
        {
            return new Dictionary<string, ClassificacaoIndicativa>
            {
                {"G", ClassificacaoIndicativa.Livre },
                {"PG", ClassificacaoIndicativa.MaioresQue10 },
                {"PG-13", ClassificacaoIndicativa.MaioresQue13 },
                {"R", ClassificacaoIndicativa.MaioresQue14 },
                {"NC-17", ClassificacaoIndicativa.MaioresQue18 }
            };
        }        

        public static string ParaString(this ClassificacaoIndicativa valor)
        {
            Dictionary<string, ClassificacaoIndicativa> mapa = MapaClassificacao();

            return mapa.First(m => m.Value == valor).Key;
        }

        public static ClassificacaoIndicativa ParaValor(this string texto)
        {
            Dictionary<string, ClassificacaoIndicativa> mapa = MapaClassificacao();

            return mapa.First(m => m.Key == texto).Value;
        }

    }
}
