using PropostaService.Core.Application.DTOs;
using PropostaService.Core.Application.Interfaces;
using PropostaService.Core.Domain.Entities;
using PropostaService.Core.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropostaService.Core.Application.UseCases
{
    public class ListarPropostasUseCase : IListarPropostasUseCase
    {
        private readonly IPropostaRepository _propostaRepository;
        public ListarPropostasUseCase(IPropostaRepository propostaRepository)
        {
            _propostaRepository = propostaRepository;
        }

        public async Task<IEnumerable<PropostaListItemDto>> ExecuteAsync()
        {
            var ret = new List<PropostaListItemDto>();
            var propostas = await _propostaRepository.GetAllAsync();
            foreach (var item in propostas)
                ret.Add(new PropostaListItemDto
                {
                    ClienteId = item.ClienteId,
                    Id = item.Id,
                    Status = item.Status,
                    Valor = item.Valor
                });

            return ret;
        }
    }
}
