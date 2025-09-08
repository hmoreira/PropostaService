using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropostaService.Core.Domain.Enums
{
    public enum StatusPropostaEnum : short
    {
        Criada = 0,
        EmAnalise = 1,
        Aprovada = 2,
        Rejeitada = 3
    }
}
