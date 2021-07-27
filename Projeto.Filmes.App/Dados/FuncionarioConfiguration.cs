using Projeto.Filmes.App.Negocio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Projeto.Filmes.App.Dados
{
    public class FuncionarioConfiguration : PessoaConfiguration<Funcionario>
    {
        public override void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            base.Configure(builder);
            builder.ToTable("staff");
            builder.Property(i => i.Id).HasColumnName("staff_id");
            builder.Property(l => l.Login).HasColumnName("username").HasColumnType("varchar(16)").IsRequired();
            builder.Property(p => p.Senha).HasColumnName("password").HasColumnType("varchar(40)");            
        }
    }
}