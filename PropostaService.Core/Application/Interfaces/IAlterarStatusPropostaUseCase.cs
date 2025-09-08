using PropostaService.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropostaService.Core.Application.Interfaces
{
    public interface IAlterarStatusPropostaUseCase
    {
        /// <summary>
        /// Altera o status de uma proposta existente.
        /// </summary>
        /// <param name="propostaId">O ID da proposta a ser alterada.</param>
        /// <param name="novoStatus">O novo status para a proposta.</param>
        /// <returns>Task representando a operação assíncrona.</returns>
        Task ExecuteAsync(Guid propostaId, StatusPropostaEnum novoStatus);
    }
}
