using Microsoft.EntityFrameworkCore;
using PropostaService.Adapters.Data;
using PropostaService.Core.Domain.Entities;
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

        
    }
}
