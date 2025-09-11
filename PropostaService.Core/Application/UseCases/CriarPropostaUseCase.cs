using PropostaService.Core.Application.DTOs;
using PropostaService.Core.Application.Interfaces;
using PropostaService.Core.Domain.Entities;
using PropostaService.Core.Domain.Interfaces;
using System.Drawing;

namespace PropostaService.Core.Application.UseCases
{    
    public class CriarPropostaUseCase : ICriarPropostaUseCase
    {
        private readonly IPropostaRepository _propostaRepository;
        public CriarPropostaUseCase(IPropostaRepository propostaRepository)
        {
            _propostaRepository = propostaRepository;
        }       

        public async Task ExecuteAsync(CriarPropostaDto criarPropostaDto)
        {            
            var proposta = Proposta.Criar(criarPropostaDto.Valor);
            
            await _propostaRepository.AddAsync(proposta);            

            //Publicar um evento se necessário (ex: para o serviço de notificação)
            // _eventPublisher.Publish(new PropostaCriadaEvent(proposta.Id, proposta.ClienteId));
        }
    }
}
