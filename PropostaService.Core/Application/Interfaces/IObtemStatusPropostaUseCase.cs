using PropostaService.Core.Domain.Enums;

namespace PropostaService.Core.Application.Interfaces
{
    public interface IObtemStatusPropostaUseCase
    {        
        Task<StatusPropostaEnum?> ExecuteAsync(Guid propostaId);        
    }
}
