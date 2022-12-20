using System;
using System.Collections.Generic;

namespace Loja.Core.Shared.ModelViews
{
    /// <summary>
    /// Objeto utilizado para inserção de novo cliente
    /// </summary>
    public class MedicoView
    {
        public int MedicoId { get; set; }
        public string Nome { get; set; }
        public string CRM { get; set; }
        public ICollection<EspecialidadeModelView> Especialidades { get; set; }
    }
}
