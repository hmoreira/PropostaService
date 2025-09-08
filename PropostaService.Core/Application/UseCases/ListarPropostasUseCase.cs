using PropostaService.Core.Application.DTOs;
using PropostaService.Core.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropostaService.Core.Application.UseCases
{
    public class ListarPropostasUseCase : IListarPropostasUseCase
    {
        public Task<IEnumerable<PropostaListItemDto>> ExecuteAsync()
        {
            throw new NotImplementedException();
        }
    }
}
