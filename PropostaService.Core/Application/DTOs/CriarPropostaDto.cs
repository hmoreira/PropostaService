using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropostaService.Core.Application.DTOs
{
    public class CriarPropostaDto
    {
        public Guid ClienteId { get; set; } 
        public decimal Valor { get; set; }
    }
}
