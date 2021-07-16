using System;
using Projeto.Filmes.App.Negocio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Projeto.Filmes.App.Dados
{
    public class FilmeAtorConfiguration : IEntityTypeConfiguration<FilmeAtor>
    {
        public void Configure(EntityTypeBuilder<FilmeAtor> builder)
        {
            builder.ToTable("film_actor");
            builder.Property<int>("film_id").IsRequired();
            builder.Property<int>("actor_id").IsRequired();
            builder.Property<DateTime>("last_update")
                .IsRequired().HasColumnType("datetime").HasDefaultValueSql("getdate()");

            builder.HasKey("film_id", "actor_id");

            builder.HasOne(f => f.Filme).WithMany(a => a.Atores).HasForeignKey("film_id");

            builder.HasOne(f => f.Ator).WithMany(f => f.Filmografia).HasForeignKey("actor_id");
        }
    }
}
