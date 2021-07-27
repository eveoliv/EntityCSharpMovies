using System;
using Projeto.Filmes.App.Negocio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Projeto.Filmes.App.Dados
{
    public class AtorConfiguration : IEntityTypeConfiguration<Ator>
    {
        public void Configure(EntityTypeBuilder<Ator> builder)
        {
            builder.ToTable("actor");
            builder.Property(i => i.Id).HasColumnName("actor_id");
            builder.Property(p => p.PrimeiroNome).HasColumnName("first_name").HasColumnType("varchar(45)").IsRequired();
            builder.Property(s => s.UltimoNome).HasColumnName("last_name").HasColumnType("varchar(45)").IsRequired();
            builder.Property<DateTime>("last_update").HasColumnType("datetime").HasDefaultValueSql("getdate()");
            builder.HasIndex(a => a.UltimoNome);

            builder.HasAlternateKey(a => new { a.PrimeiroNome, a.UltimoNome });

        }
    }
}
