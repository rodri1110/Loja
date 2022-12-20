using System.Collections.Generic;

namespace Loja.Core.Domain
{
    public class Medico_Especialidade
    {
        public int MedicoId { get; set; }
        public Medico Medico { get; set; }
        public int EspecialidadeId { get; set; }
        public Especialidade Especialidade { get; set; }
    }
}