using Microsoft.EntityFrameworkCore;
using PropostaService.Adapters.Data;
using PropostaService.Core.Domain.Entities;
using PropostaService.Core.Domain.Enums;
using PropostaService.Core.Domain.Interfaces;

namespace PropostaService.Adapters.Persistence
{
    public class PropostaRepository : IPropostaRepository
    {
        private readonly PropostaDbContext _context;

        public PropostaRepository(PropostaDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task AddAsync(Proposta proposta)
        {
            await _context.Propostas.AddAsync(proposta);
            await _context.SaveChangesAsync(); 
        }        

        public async Task<IEnumerable<Proposta>> GetAllAsync()
        {
            return await _context.Propostas.ToListAsync();
        }

        public async Task UpdateStatusAsync(Guid propostaId, StatusPropostaEnum statusProposta)
        {
            var ret = await _context.Propostas.FindAsync(propostaId);
            if (ret != null)
            {
                ret.Status = statusProposta;
                await _context.SaveChangesAsync();
            }
            else throw new Exception("Proposta não encontrada");
        }
    }
}
