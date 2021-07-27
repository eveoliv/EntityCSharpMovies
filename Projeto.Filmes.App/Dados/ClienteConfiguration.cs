using System;
using Projeto.Filmes.App.Negocio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Projeto.Filmes.App.Dados
{
    public class ClienteConfiguration : PessoaConfiguration<Cliente>
    {
        public override void Configure(EntityTypeBuilder<Cliente> builder)
        {
            base.Configure(builder);
            builder.ToTable("customer");
            builder.Property(i => i.Id).HasColumnName("customer_id");            
            builder.Property<DateTime>("create_date").HasColumnType("datetime").HasDefaultValueSql("getdate()").IsRequired();                    
        }
    }
}
