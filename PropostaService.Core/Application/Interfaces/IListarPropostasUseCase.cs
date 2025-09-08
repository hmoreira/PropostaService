using PropostaService.Core.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropostaService.Core.Application.Interfaces
{
    public interface IListarPropostasUseCase
    {
        /// <summary>
        /// Lista todas as propostas de seguro.
        /// </summary>
        /// <returns>Uma coleção de DTOs representando as propostas.</returns>
        Task<IEnumerable<PropostaListItemDto>> ExecuteAsync();

        // Ou com filtros/paginação:
        // Task<PagedResultDto<PropostaListItemDto>> ExecuteAsync(ListPropostasFilterDto filter);
    }
}
