using Microsoft.EntityFrameworkCore;
using PropostaService.Adapters.Data;
using PropostaService.Core.Application.DTOs;
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

        public async Task<Proposta?> GetAsync(Guid propostaId)
        {
            return await _context.Propostas.FindAsync(propostaId);            
        }

        public async Task<PropostaResponseDto?> GetStatusAsync(Guid propostaId)
        {
            var ret = await _context.Propostas.FindAsync(propostaId);
            if (ret != null)
                return new PropostaResponseDto
                {
                    PropostaId = ret.Id,
                    Status = ret.Status
                };
            else
                return null;
        }

        public async Task<StatusPropostaEnum?> ObtemStatusPropostaAsync(Guid propostaId)
        {
            var ret = await _context.Propostas.FindAsync(propostaId);
            if (ret != null)
                return ret.Status;
            else
                return (StatusPropostaEnum?)null;
        }

        public async Task UpdateAsync(Proposta proposta)
        {
            _context.Propostas.Update(proposta);
            await _context.SaveChangesAsync();
        }

        Task<Proposta?> IPropostaRepository.GetAsync(Guid propostaId)
        {
            throw new NotImplementedException();
        }
    }
}
