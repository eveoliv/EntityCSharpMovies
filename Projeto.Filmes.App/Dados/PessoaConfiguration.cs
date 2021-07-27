using System;
using Projeto.Filmes.App.Negocio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Projeto.Filmes.App.Dados
{
    public class PessoaConfiguration<T> : IEntityTypeConfiguration<T> where T : Pessoa
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {           
            builder.Property(p => p.PrimeiroNome).HasColumnName("first_name").HasColumnType("varchar(45)").IsRequired();
            builder.Property(u => u.UltimoroNome).HasColumnName("last_name").HasColumnType("varchar(45)").IsRequired();
            builder.Property(e => e.Email).HasColumnName("email").HasColumnType("varchar(50)");
            builder.Property(a => a.Ativo).HasColumnName("active");
            builder.Property<DateTime>("last_update").HasColumnType("datetime").HasDefaultValueSql("getdate()").IsRequired();
        }
    }
}