using Loja.Core.Domain;
using Loja.Data.Context;
using Loja.Manager.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Data.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly LojaContext _context;

        public ClienteRepository(LojaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cliente>> ListaClientesAsync()
        {
            return await _context.Clientes
                .Include(c => c.Endereco)
                .Include(c => c.Telefones)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Cliente> ListaClienteAsync(int id)
        {
            return await _context.Clientes
                .Include(c => c.Endereco)
                .Include(c => c.Telefones)
                .SingleOrDefaultAsync(c => c.ClienteId == id);
        }

        public async Task<Cliente> SalvarClienteAsync(Cliente cliente)
        {
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task<Cliente> AtualizarClienteAsync(Cliente cliente)
        {
            var clienteConsultado = await ListaClienteAsync(cliente.ClienteId);
            if (clienteConsultado == null){ return null; }
            
            if (clienteConsultado.Endereco == null)
            {
                clienteConsultado.Endereco = new Endereco()
                {
                    CEP = cliente.Endereco.CEP,
                    Cidade = cliente.Endereco.Cidade, 
                    ClienteId = cliente.ClienteId,
                    Complemento = cliente.Endereco.Complemento,
                    Estado = cliente.Endereco.Estado,
                    Logradouro = cliente.Endereco.Logradouro,
                    Numero = cliente.Endereco.Numero
                };
            }

            cliente.DataDeCriacao = clienteConsultado.DataDeCriacao;
            
            //O Entry altera os dados no tracking e o saveChanges altera na base, não é necessário o .Update();
            _context.Entry(clienteConsultado).CurrentValues.SetValues(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var cliente = await ListaClienteAsync(id);
            if (cliente == null) { return false; }
            _context.Clientes.Remove(cliente);
            var saveStatus = await _context.SaveChangesAsync();
            return saveStatus > 0 ? true : false;
        }
    }
}
