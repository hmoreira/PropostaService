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
        public Task<StatusPropostaEnum?> ObtemStatusPropostaAsync(Guid propostaId);
        public Task UpdateStatusAsync(Guid propostaId, StatusPropostaEnum statusProposta); 
    }
}
