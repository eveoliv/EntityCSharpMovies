using System;
using Projeto.Filmes.App.Negocio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Projeto.Filmes.App.Dados
{
    class IdiomaConfiguration : IEntityTypeConfiguration<Idioma>
    {
        public void Configure(EntityTypeBuilder<Idioma> builder)
        {
            builder.ToTable("language");

            builder.Property(l => l.Id).HasColumnName("language_id");
            builder.Property(n => n.Nome).HasColumnName("name").HasColumnType("char(20)").IsRequired();   
            builder.Property<DateTime>("last_update").HasColumnType("datetime").HasDefaultValueSql("getdate()").IsRequired();
        }
    }
}
