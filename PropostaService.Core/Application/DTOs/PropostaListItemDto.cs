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
        public Guid Id { get; set; }
        public Guid ClienteId { get; set; } 
        public decimal Valor { get; set; }
        public StatusPropostaEnum Status { get; set; } // Enum: EmAnalise, Aprovada, Rejeitada
    }
}
