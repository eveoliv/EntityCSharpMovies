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
            builder.Property<byte>("language_id");
            builder.Property<byte?>("original_language_id");
            builder.Property(c => c.TextoClassificacao).HasColumnName("rating").HasColumnType("varchar(10)");
            builder.Ignore(c => c.Classificacao);

            builder.HasOne(i => i.IdiomaFalado).WithMany(f => f.FilmesFalados).HasForeignKey("language_id");
            builder.HasOne(i => i.IdiomaOriginal).WithMany(f => f.FilmesOriginais).HasForeignKey("original_language_id");
        }
    }
}
