using PropostaService.Core.Application.Interfaces;
using PropostaService.Core.Domain.Enums;
using PropostaService.Core.Domain.Interfaces;
using PropostaService.Core.Domain.Exceptions;

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
            var proposta = await _propostaRepository.GetAsync(propostaId);
            if (proposta == null)
                throw new DomainException($"Proposta {propostaId} não encontrada");
            
            proposta.AlterarStatus(novoStatus);
            await _propostaRepository.UpdateAsync(proposta);
        }
    }
}
