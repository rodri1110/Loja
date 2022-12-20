using Loja.Core.Domain;
using Loja.Core.Shared.ModelViews;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Loja.Manager.Interfaces
{
    public interface IClienteService
    {
        Task<IEnumerable<Cliente>> ListaClientesAsync();
        Task<Cliente> ListaClienteAsync(int id);
        Task<Cliente> SalvarClienteAsync(ClienteModelView cliente);
        Task<Cliente> AtualizarClienteAsync(AtualizarClienteModelView cliente);
        Task<bool> DeletarCliente(int id);
    }
}
