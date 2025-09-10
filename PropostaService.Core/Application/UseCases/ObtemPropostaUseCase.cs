using PropostaService.Core.Application.DTOs;
using PropostaService.Core.Application.Interfaces;
using PropostaService.Core.Domain.Entities;
using PropostaService.Core.Domain.Interfaces;

namespace PropostaService.Core.Application.UseCases
{
    public class ObtemPropostaUseCase : IObtemPropostaUseCase
    {
        private readonly IPropostaRepository _propostaRepository;
        public ObtemPropostaUseCase(IPropostaRepository propostaRepository)
        {
            _propostaRepository = propostaRepository;
        }

        public async Task<PropostaResponseDto?> ExecuteAsync(Guid propostaId)
        {
            return await _propostaRepository.GetStatusAsync(propostaId);
        }        
    }
}
