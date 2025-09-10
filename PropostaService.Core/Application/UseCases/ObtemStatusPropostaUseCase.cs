using PropostaService.Core.Application.Interfaces;
using PropostaService.Core.Domain.Enums;
using PropostaService.Core.Domain.Interfaces;

namespace PropostaService.Core.Application.UseCases
{
    public class ObtemStatusPropostaUseCase : IObtemStatusPropostaUseCase
    {
        private readonly IPropostaRepository _propostaRepository;
        public ObtemStatusPropostaUseCase(IPropostaRepository propostaRepository)
        {
            _propostaRepository = propostaRepository;
        }

        public async Task<StatusPropostaEnum?> ExecuteAsync(Guid propostaId)
        {
            return await _propostaRepository.ObtemStatusPropostaAsync(propostaId);
        }        
    }
}
