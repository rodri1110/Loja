using Loja.Core.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Loja.Manager.Interfaces
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> ListaClientesAsync();
        Task<Cliente> ListaClienteAsync(int id);
        Task<Cliente> SalvarClienteAsync(Cliente cliente);
        Task<Cliente> AtualizarClienteAsync(Cliente cliente);
        Task<bool> DeleteAsync(int id);
    }
}
