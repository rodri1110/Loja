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
    public class MedicoRepository : IMedicoRepository
    {
        private readonly LojaContext _context;

        public MedicoRepository(LojaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Medico>> ListaMedicosAsync()
        {
            return await _context.Medicos
                .Include(c => c.Especialidades)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Medico> ListaMedicoAsync(int id)
        {
            return await _context.Medicos
                .Include(c => c.Especialidades)
                .SingleOrDefaultAsync(c => c.MedicoId == id);
        }

        public async Task<Medico> SalvarMedicoAsync(Medico medico)
        {
            await _context.Medicos.AddAsync(medico);
            await _context.SaveChangesAsync();
            return medico;
        }

        public async Task<Medico> AtualizarMedicoAsync(Medico medico)
        {
            var medicoConsultado = await ListaMedicoAsync(medico.MedicoId);
            if (medicoConsultado == null){ return null; }
            
            //O Entry altera os dados no tracking e o saveChanges altera na base, não é necessário o .Update();
            _context.Entry(medicoConsultado).CurrentValues.SetValues(medico);
            await _context.SaveChangesAsync();
            return medico;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var medico = await ListaMedicoAsync(id);
            if (medico == null) { return false; }
            _context.Medicos.Remove(medico);
            var saveStatus = await _context.SaveChangesAsync();
            return saveStatus > 0 ? true : false;
        }
    }
}
