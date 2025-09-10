using PropostaService.Core.Application.DTOs;
using PropostaService.Core.Domain.Entities;
using PropostaService.Core.Domain.Enums;

namespace PropostaService.Core.Application.Interfaces
{
    public interface IObtemPropostaUseCase
    {        
        Task<PropostaResponseDto?> ExecuteAsync(Guid propostaId);        
    }
}
