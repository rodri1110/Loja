using System;
using System.Collections.Generic;

namespace Loja.Core.Shared.ModelViews
{
    /// <summary>
    /// Objeto utilizado para inserção de novo cliente
    /// </summary>
    public class NovoMedicoView
    {
        public string Nome { get; set; }
        public string CRM { get; set; }
        public ICollection<ReferenciaEspecialidade> Especialidades { get; set; }
    }
}
