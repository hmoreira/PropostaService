using PropostaService.Core.Application.DTOs;
using PropostaService.Core.Application.Interfaces;

namespace PropostaService.Core.Application.UseCases
{
    public class CriarPropostaUseCase : ICriarPropostaUseCase
    {
        public Task<Guid> ExecuteAsync(CriarPropostaDto criarPropostaDto)
        {
            throw new NotImplementedException();
        }
    }
}
