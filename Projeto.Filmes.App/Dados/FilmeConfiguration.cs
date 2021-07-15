using System;
using Projeto.Filmes.App.Negocio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Projeto.Filmes.App.Dados
{
    public class FilmeConfiguration : IEntityTypeConfiguration<Filme>
    {
        public void Configure(EntityTypeBuilder<Filme> builder)
        {
            builder.ToTable("film");
            builder.Property(i => i.Id).HasColumnName("film_id");
            builder.Property(t => t.Titulo).HasColumnName("title").HasColumnType("varchar(255)");
            builder.Property(d => d.Descricao).HasColumnName("description").HasColumnType("text");
            builder.Property(a => a.AnoLancamento).HasColumnName("release_year").HasColumnType("varchar(4)");
            builder.Property(d => d.Duracao).HasColumnName("length");
            builder.Property<DateTime>("last_update").HasColumnType("datetime").IsRequired();
        }
    }
}
