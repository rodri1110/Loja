using Loja.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loja.Data.Configuration
{
    class Medico_EspecialidadeConfiguration : IEntityTypeConfiguration<Medico_Especialidade>
    {
        public void Configure(EntityTypeBuilder<Medico_Especialidade> builder) 
        {
            builder.HasKey(p => new { p.MedicoId, p.EspecialidadeId });
            builder.HasOne(p => p.Medico).WithMany(p => p.Especialidades);
            builder.HasOne(p => p.Especialidade).WithMany(p => p.Medicos);
        }
    }
}
