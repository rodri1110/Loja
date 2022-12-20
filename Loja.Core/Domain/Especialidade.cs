using System.Collections.Generic;

namespace Loja.Core.Domain
{
    public class Especialidade
    {
        public int EspecialidadeId { get; set; }
        public string Descricao { get; set; }
        public ICollection<Medico_Especialidade> Medicos { get; set; }
    }
}