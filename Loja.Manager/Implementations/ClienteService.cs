using AutoMapper;
using Loja.Core.Domain;
using Loja.Core.Shared.ModelViews;
using Loja.Manager.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Manager.Implementations
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<ClienteService> _logger;

        public ClienteService(IClienteRepository repository, IMapper mapper, ILogger<ClienteService> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<Cliente>> ListaClientesAsync()
        {
            return await _repository.ListaClientesAsync();
        }

        public async Task<Cliente> ListaClienteAsync(int id)
        {
            return await _repository.ListaClienteAsync(id);
        }

        public async Task<Cliente> SalvarClienteAsync(ClienteModelView clienteModelView)
        {
            _logger.LogInformation("Request de negócio p/ o repositório de inserção de novo cliente.");
            var cliente = _mapper.Map<Cliente>(clienteModelView);
            return await _repository.SalvarClienteAsync(cliente);
        }

        public async Task<Cliente> AtualizarClienteAsync(AtualizarClienteModelView clienteModelView)
        {
            var cliente = _mapper.Map<Cliente>(clienteModelView);
            return await _repository.AtualizarClienteAsync(cliente);
        }

        public async Task<bool> DeletarCliente(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
