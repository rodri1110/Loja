using System;
using System.Collections.Generic;
using System.Text;

namespace Loja.Core.Domain
{
    public class Medico
    {
        public int MedicoId { get; set; }
        public string Nome { get; set; }
        public string CRM { get; set; }
        public ICollection<Medico_Especialidade> Especialidades { get; set; }
    }
}
