using Loja.Core.Domain;
using Loja.Core.Shared.ModelViews;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Manager.Interfaces
{
    public interface IMedicoService
    {
        Task<IEnumerable<MedicoView>> ListaMedicosAsync();

        Task<MedicoView> ListaMedicoAsync(int id);

        Task<MedicoView> SalvarMedicoAsync(MedicoView medicoView);

        Task<MedicoView> AtualizarMedicoAsync(AtualizarMedicoModelView medicoView);

        Task<bool> DeletarMedico(int id);
    }
}
