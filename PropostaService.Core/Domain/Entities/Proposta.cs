using PropostaService.Core.Domain.Enums;
using PropostaService.Core.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropostaService.Core.Domain.Entities
{
    public class Proposta
    {
        public Guid Id { get; private set; }
        public Guid ClienteId { get; private set; } 
        public decimal Valor { get; private set; }
        public StatusPropostaEnum Status { get; private set; } // Enum: EmAnalise, Aprovada, Rejeitada

        // Construtor privado para forçar o uso de métodos de fábrica ou construtores de fábrica
        private Proposta(Guid id, Guid clienteId, decimal valor)
        {
            Id = id;
            ClienteId = clienteId;
            Valor = valor;
            Status = StatusPropostaEnum.EmAnalise; // Status inicial padrão
        }

        public static Proposta Criar(Guid clienteId, decimal valor)
        {
            // Validações de negócio antes de criar
            if (clienteId == Guid.Empty)
                throw new DomainException("O id do cliente é obrigatório.");            
            if (valor <= 0)
                throw new DomainException("O valor da proposta deve ser positivo.");

            return new Proposta(Guid.NewGuid(), clienteId, valor);
        }

        // Método para alterar o status
        public void AlterarStatus(StatusPropostaEnum statusProposta)
        {
            Status = statusProposta;
        }
    }
}
