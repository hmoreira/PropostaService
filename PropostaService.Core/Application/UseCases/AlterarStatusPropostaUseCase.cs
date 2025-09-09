using PropostaService.Core.Application.Interfaces;
using PropostaService.Core.Domain.Enums;
using PropostaService.Core.Domain.Interfaces;

namespace PropostaService.Core.Application.UseCases
{
    public class AlterarStatusPropostaUseCase : IAlterarStatusPropostaUseCase
    {
        private readonly IPropostaRepository _propostaRepository;
        public AlterarStatusPropostaUseCase(IPropostaRepository propostaRepository)
        {
            _propostaRepository = propostaRepository;
        }

        public async Task ExecuteAsync(Guid propostaId, StatusPropostaEnum novoStatus)
        {
            await _propostaRepository.UpdateStatusAsync(propostaId, novoStatus);
        }
    }
}
