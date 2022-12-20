using Loja.Core.Shared.ModelViews;
using System;
using System.Collections.Generic;

namespace Loja.Core.Domain
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public char Sexo { get; set; }

        //1 para muitos, incluir no contexto (DbSet), configuração
        public ICollection<Telefone> Telefones { get; set; }
        public string Documento { get; set; }
        public DateTime DataDeCriacao { get; set; }
        public DateTime? UltimaAtualizacao { get; set; }

        // Criando relacionamento 1 x 1 entre Cliente x Endereço
        // Neste exemplo
        // 1 Cliente pode possuir apenas 1 Endereço.
        // e 1 Endereço pode pertencer a apenas 1 Cliente.

        public Endereco Endereco { get; set; }

        public Cliente()
        {
        }
    }
}
