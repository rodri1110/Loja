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
    public class MedicoService : IMedicoService
    {
        private readonly IMedicoRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<MedicoService> _logger;

        public MedicoService(IMedicoRepository repository, IMapper mapper, ILogger<MedicoService> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<MedicoView>> ListaMedicosAsync()
        {
            return _mapper.Map<List<MedicoView>>(await _repository.ListaMedicosAsync());
        }

        public async Task<MedicoView> ListaMedicoAsync(int id)
        {
            return _mapper.Map<MedicoView>(await _repository.ListaMedicoAsync(id));
        }

        public async Task<MedicoView> SalvarMedicoAsync(MedicoView medicoView)
        {
            _logger.LogInformation("Request de negócio p/ o repositório de inserção de novo cliente.");
            var medico = _mapper.Map<Medico>(medicoView);
            return _mapper.Map<MedicoView>(await _repository.SalvarMedicoAsync(medico));
        }

        public async Task<MedicoView> AtualizarMedicoAsync(AtualizarMedicoModelView medicoView)
        {
            var medico = _mapper.Map<Medico>(medicoView);
            return _mapper.Map<MedicoView>(await _repository.AtualizarMedicoAsync(medico));
        }

        public async Task<bool> DeletarMedico(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
