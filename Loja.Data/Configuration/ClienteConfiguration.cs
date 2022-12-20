using Loja.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loja.Data.Configuration
{
    class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder) 
        {
            //O builder já está tipado e por isso não é necessário
            //modelBuilder.Entity<Cliente>().HasKey(p => p.ClienteId);
            //builder.ToTable("Usuarios");

            //Exemplos de alterações de propriedade
            //builder.ToTable("Usuarios");
            //builder.Property(p => p.Sexo).HasDefaultValue('M').IsRequired();
            //builder.Property(p => p.Documento).HasColumnName("DocumentoIdentidicador");
            //builder.HasIndex(p => new { p.Nome, p.Sexo });
            //builder.Property(p => p.DataNascimento).HasColumnType("varchar");

            builder.HasKey(p => p.ClienteId);
            builder.Property(p => p.Nome).HasMaxLength(200).IsRequired();
        }
    }
}
