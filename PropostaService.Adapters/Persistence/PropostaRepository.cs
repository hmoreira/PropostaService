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
            await _context.SaveChangesAsync(); // Salva imediatamente ou deixe para o Use Case decidir quando salvar.
        }

        public async Task<Proposta?> GetByIdAsync(Guid id)
        {
            return await _context.Propostas.FindAsync(id);
        }

        public async Task<IEnumerable<Proposta>> GetAllAsync()
        {
            return await _context.Propostas.ToListAsync();
        }

        public async Task UpdateAsync(Proposta proposta)
        {
            // O EF Core rastreia as entidades. Se a entidade já existe no contexto,
            // `Update` pode não ser necessário. `SaveChangesAsync` cuida das mudanças.
            // No entanto, para garantir que todas as propriedades sejam salvas, você pode usar:
            _context.Propostas.Update(proposta);
            await _context.SaveChangesAsync();
        }

        // Implemente outros métodos conforme definido em IPropostaRepository
    }
}
