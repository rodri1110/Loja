using Loja.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loja.Data.Configuration
{
    public class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(p => p.EnderecoId);
            builder.HasOne(p => p.Cliente)
                .WithOne(p => p.Endereco)
                .HasForeignKey<Endereco>(p => p.ClienteId);
        }
    }
}
