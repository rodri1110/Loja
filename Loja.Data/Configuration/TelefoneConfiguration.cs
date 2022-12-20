using Loja.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loja.Data.Configuration
{
    public class TelefoneConfiguration : IEntityTypeConfiguration<Telefone>
    {
        public void Configure(EntityTypeBuilder<Telefone> builder)
        {
            //O Entity entende e aplica de forma implícita estas configurações (exceto os comportamentos), pq criamos da forma correta ambas as classes, mas deixaremos para fins didáticos
            //Definindo uma chave composta
            builder.HasKey(p => new { p.ClienteId, p.Numero });
            builder.HasOne(p => p.Cliente)
                .WithMany(p => p.Telefones)
                .OnDelete(DeleteBehavior.Cascade);
            
            //Alguns comportamentos podem ser criados
            // ex: .IsRequired(); para obrigatoriedade do telefone
            // ex 2: Ao deletar cliente podemos excluir tbm o telefone com .OnDelete(DeleteBehavior.Cascade)
        }
    }
}
