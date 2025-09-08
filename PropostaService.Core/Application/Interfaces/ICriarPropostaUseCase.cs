using PropostaService.Core.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropostaService.Core.Application.Interfaces
{
    public interface ICriarPropostaUseCase
    {
        /// <summary>
        /// Cria uma nova proposta de seguro com os dados fornecidos.
        /// </summary>
        /// <param name="criarPropostaDto">DTO contendo os dados da proposta a ser criada.</param>
        /// <returns>O ID da proposta recém-criada.</returns>
        Task<Guid> ExecuteAsync(CriarPropostaDto criarPropostaDto);
    }
}
