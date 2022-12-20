using Loja.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Manager.Interfaces
{
    public interface IMedicoRepository
    {
        Task<IEnumerable<Medico>> ListaMedicosAsync();

        Task<Medico> ListaMedicoAsync(int id);

        Task<Medico> SalvarMedicoAsync(Medico medico);

        Task<Medico> AtualizarMedicoAsync(Medico medico);

        Task<bool> DeleteAsync(int id);
    }
}
