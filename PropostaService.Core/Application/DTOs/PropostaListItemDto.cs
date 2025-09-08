using PropostaService.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropostaService.Core.Application.DTOs
{
    public class PropostaListItemDto
    {
        public Guid Id { get; private set; }
        public Guid ClienteId { get; private set; } 
        public decimal Valor { get; private set; }
        public StatusPropostaEnum Status { get; private set; } // Enum: EmAnalise, Aprovada, Rejeitada
    }
}
