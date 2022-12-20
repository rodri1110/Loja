using System;
using System.Collections.Generic;

namespace Loja.Core.Shared.ModelViews
{
    /// <summary>
    /// Objeto utilizado para inserção de novo cliente
    /// </summary>
    public class ClienteModelView
    {
        /// <summary>
        /// Nome do Cliente
        /// </summary>
        /// <example>Rodrigo Oliveira</example>
        public string Nome { get; set; }
        /// <summary>
        /// Data de Nascimento
        /// </summary>
        /// <example>1985-10-11</example>
        public DateTime DataNascimento { get; set; }
        /// <summary>
        /// Sexo do cliente
        /// </summary>
        /// <example>M</example>
        public char Sexo { get; set; }
        /// <summary>
        /// Telefone do cliente
        /// </summary>
        /// 16999887755
        public ICollection<TelefoneModelView> Telefones { get; set; }
        /// <summary>
        /// Documento do cliente: CNH, CPF, RG
        /// </summary>
        /// <example>445556669</example>
        public string Documento { get; set; }
        public EnderecoModelView Endereco { get; set; }
    }
}
