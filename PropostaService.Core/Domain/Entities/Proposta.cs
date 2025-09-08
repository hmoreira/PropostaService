using PropostaService.Core.Domain.Enums;
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
        public Guid ClienteId { get; private set; } // Apenas o ID do cliente
        public decimal Valor { get; private set; }
        public StatusPropostaEnum Status { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public DateTime? DataUltimaAtualizacao { get; private set; }

        // Construtor privado para garantir o uso de métodos de fábrica ou de criação específicos
        private Proposta() { }

        // Construtor ou método de fábrica para criar uma nova proposta
        public static Proposta Criar(Guid clienteId, decimal valor)
        {
            // Validações iniciais (ex: clienteId não pode ser nulo, valor não pode ser negativo)
            if (clienteId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(clienteId));
            }
            if (valor <= 0)
            {
                throw new ArgumentException("O valor da proposta deve ser positivo.", nameof(valor));
            }

            return new Proposta
            {
                Id = Guid.NewGuid(),
                ClienteId = clienteId,
                Valor = valor,
                Status = StatusPropostaEnum.EmAnalise, // Status inicial
                DataCriacao = DateTime.UtcNow,
                DataUltimaAtualizacao = DateTime.UtcNow
            };
        }

        // Método para alterar o status
        public void AlterarStatus(StatusPropostaEnum novoStatus)
        {
            // Lógica de negócio para transição de estados (ex: não pode ir de Rejeitada para Aprovada)
            if (this.Status == StatusPropostaEnum.Aprovada && novoStatus != StatusPropostaEnum.Aprovada)
            {
                // Exemplo de exceção de negócio
                throw new StatusPropostaInvalidoException($"Não é possível alterar o status de uma proposta já Aprovada para {novoStatus}.");
            }

            this.Status = novoStatus;
            this.DataUltimaAtualizacao = DateTime.UtcNow;

            // Opcional: Lançar um evento de domínio, se necessário
            // Ex: if (novoStatus == StatusProposta.Aprovada) { AdicionarDominioEvent(new PropostaAprovadaEvent(Id, ClienteId)); }
        }

        // Exemplo de Exceção Customizada
        // Em MeuServico.Proposta.Core/Domain/Exceptions/StatusPropostaInvalidoException.cs
        public class StatusPropostaInvalidoException : Exception
        {
            public StatusPropostaInvalidoException(string message) : base(message) { }
        }
    }
}
