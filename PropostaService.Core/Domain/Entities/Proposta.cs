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
        public Guid Id { get; set; }
        public Guid ClienteId { get; set; } // Apenas o ID é suficiente para o domínio da proposta
        public decimal Valor { get; set; }
        public StatusPropostaEnum Status { get; set; } // Enum: EmAnalise, Aprovada, Rejeitada

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
                throw new DomainException("O ClienteId é obrigatório.");
            if (valor <= 0)
                throw new DomainException("O valor da proposta deve ser positivo.");

            return new Proposta(Guid.NewGuid(), clienteId, valor);
        }

        // Método para alterar o status
        public void AlterarStatus(StatusPropostaEnum novoStatus)
        {
            // Lógica de transição de estado (se houver regras específicas)
            if (Status == StatusPropostaEnum.Aprovada && novoStatus != StatusPropostaEnum.Aprovada)
                throw new DomainException("Propostas aprovadas não podem ter o status alterado.");
            if (Status == StatusPropostaEnum.Rejeitada && novoStatus != StatusPropostaEnum.Rejeitada)
                throw new DomainException("Propostas rejeitadas não podem ter o status alterado.");

            Status = novoStatus;
            // Opcional: Publicar um evento de domínio aqui, se necessário
            // DomainEvents.Raise(new PropostaStatusAlteradaEvent(Id, Status));
        }
    }
}
