using PropostaService.Core.Application.DTOs;
using PropostaService.Core.Domain.Entities;
using PropostaService.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropostaService.Core.Domain.Interfaces
{
    public interface IPropostaRepository
    {
        public Task AddAsync(Proposta proposta);
        public Task<IEnumerable<Proposta>> GetAllAsync();
        public Task<Proposta?> GetAsync(Guid propostaId);
        public Task<PropostaResponseDto?> GetStatusAsync(Guid propostaId);
        public Task UpdateAsync(Proposta proposta); 
    }
}
