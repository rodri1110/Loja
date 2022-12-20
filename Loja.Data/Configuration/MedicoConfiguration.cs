using Loja.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loja.Data.Configuration
{
    class MedicoConfiguration : IEntityTypeConfiguration<Medico>
    {
        public void Configure(EntityTypeBuilder<Medico> builder) 
        {
            builder.HasKey(p => p.MedicoId);            
            builder.Property(p => p.Nome).HasMaxLength(200).IsRequired();
        }
    }
}
