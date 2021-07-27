namespace Projeto.Filmes.App.Negocio
{
    public class Pessoa
    {
        public byte Id { get; set; }
        public string PrimeiroNome { get; set; }
        public string UltimoroNome { get; set; }
        public string Email { get; set; }
        public bool Ativo { get; set; }

        public override string ToString()
        {
            var tipo = GetType().Name;
            return $"{tipo} ({Id}): {PrimeiroNome} {UltimoroNome} - {Ativo}";
        }
    }
}
