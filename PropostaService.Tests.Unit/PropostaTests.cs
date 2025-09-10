using PropostaService.Core.Domain.Entities;
using PropostaService.Core.Domain.Enums;
using PropostaService.Core.Domain.Exceptions;
using System;
using Xunit;

namespace PropostaService.Tests.Unit
{
    public class PropostaTests
    {
        // ----------------------------------------------------
        // Cenários de Teste para o Método Estático Criar()
        // ----------------------------------------------------

        [Fact]
        public void Criar_DeveRetornarPropostaValida_QuandoDadosSaoCorretos()
        {            
            var clienteId = Guid.NewGuid();
            var valor = 100.00m;
            
            var proposta = Proposta.Criar(clienteId, valor);
            
            Assert.NotNull(proposta);
            Assert.IsType<Proposta>(proposta);
            Assert.NotEqual(Guid.Empty, proposta.Id);
            Assert.Equal(clienteId, proposta.ClienteId);
            Assert.Equal(valor, proposta.Valor);
            Assert.Equal(StatusPropostaEnum.EmAnalise, proposta.Status);
        }

        [Fact]
        public void Criar_DeveLancarExcecao_QuandoClienteIdForVazio()
        {            
            var clienteId = Guid.Empty;
            var valor = 500.00m;
            
            var exception = Assert.Throws<DomainException>(() =>
            {
                Proposta.Criar(clienteId, valor);
            });

            Assert.Equal("O id do cliente é obrigatório.", exception.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-10.00)]
        public void Criar_DeveLancarExcecao_QuandoValorForInvalido(decimal valorInvalido)
        {            
            var clienteId = Guid.NewGuid();
            
            var exception = Assert.Throws<DomainException>(() =>
            {
                Proposta.Criar(clienteId, valorInvalido);
            });

            Assert.Equal("O valor da proposta deve ser positivo.", exception.Message);
        }
    }
}