using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropostaService.Core.Domain.Enums;

namespace PropostaService.Core.Application.DTOs
{
    public class PropostaResponseDto
    {
        public Guid PropostaId { get; set; }
        public StatusPropostaEnum Status { get; set; }
    }
}
