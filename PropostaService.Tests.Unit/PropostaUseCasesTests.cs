using Moq;
using PropostaService.Core.Application.DTOs;
using PropostaService.Core.Application.UseCases;
using PropostaService.Core.Domain.Entities;
using PropostaService.Core.Domain.Enums;
using PropostaService.Core.Domain.Exceptions;
using PropostaService.Core.Domain.Interfaces;

namespace PropostaService.Tests.Unit
{
    public class PropostaUseCasesTests
    {        
        [Fact]
        public async Task CriarProposta_DeveAdicionarPropostaCorretamente_AoRepositorio()
        {            
            var propostaRepositoryMock = new Mock<IPropostaRepository>();
            var useCase = new CriarPropostaUseCase(propostaRepositoryMock.Object);
            var criarPropostaDto = new CriarPropostaDto
            {
                ClienteId = Guid.NewGuid(),
                Valor = 1500.00m
            };
            
            await useCase.ExecuteAsync(criarPropostaDto);
            
            propostaRepositoryMock.Verify(repo => repo.AddAsync(It.IsAny<Proposta>()), Times.Once);
        }        

        [Fact]
        public async Task AlterarStatus_DeveChamarMetodoAlterarStatus_EAtualizarRepositorio()
        {            
            var propostaId = Guid.NewGuid();
            var propostaExistente = Proposta.Criar(propostaId, 1000m);
            var propostaRepositoryMock = new Mock<IPropostaRepository>();
            propostaRepositoryMock.Setup(repo => repo.GetAsync(propostaId)).ReturnsAsync(propostaExistente);
            var useCase = new AlterarStatusPropostaUseCase(propostaRepositoryMock.Object);
            
            await useCase.ExecuteAsync(propostaId, StatusPropostaEnum.Aprovada);
            
            Assert.Equal(StatusPropostaEnum.Aprovada, propostaExistente.Status);
            propostaRepositoryMock.Verify(repo => repo.UpdateAsync(It.IsAny<Proposta>()), Times.Once);
        }

        [Fact]
        public async Task AlterarStatus_DeveLancarExcecao_QuandoPropostaNaoForEncontrada()
        {            
            var propostaId = Guid.NewGuid();
            var propostaRepositoryMock = new Mock<IPropostaRepository>();            
            propostaRepositoryMock.Setup(repo => repo.GetStatusAsync(propostaId)).Returns(Task.FromResult<PropostaResponseDto?>(null));
            var useCase = new AlterarStatusPropostaUseCase(propostaRepositoryMock.Object);
            
            await Assert.ThrowsAsync<DomainException>(() =>
                useCase.ExecuteAsync(propostaId, StatusPropostaEnum.Aprovada));

            propostaRepositoryMock.Verify(repo => repo.UpdateAsync(It.IsAny<Proposta>()), Times.Never);
        }        

        [Fact]
        public async Task ListarPropostas_DeveRetornarListaDePropostas_CorretamenteMapeadas()
        {            
            var propostaRepositoryMock = new Mock<IPropostaRepository>();
            var propostasDoRepo = new List<Proposta>
            {
                Proposta.Criar(Guid.NewGuid(), 100m),
                Proposta.Criar(Guid.NewGuid(), 200m)
            };
            propostaRepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(propostasDoRepo);
            var useCase = new ListarPropostasUseCase(propostaRepositoryMock.Object);
            
            var propostasDto = await useCase.ExecuteAsync();
            
            Assert.Equal(2, propostasDto.Count());
            Assert.Contains(propostasDto, dto => dto.Valor == 100m);
            Assert.Contains(propostasDto, dto => dto.Valor == 200m);
        }        

        [Fact]
        public async Task ObtemProposta_DeveRetornarProposta_QuandoEncontrada()
        {            
            var propostaId = Guid.NewGuid();
            var propostaDtoMock = new PropostaResponseDto
            {
                PropostaId = propostaId,
                Status = StatusPropostaEnum.EmAnalise
            };

            var propostaRepositoryMock = new Mock<IPropostaRepository>();            
            propostaRepositoryMock.Setup(repo => repo.GetStatusAsync(propostaId)).ReturnsAsync(propostaDtoMock);

            var useCase = new ObtemPropostaUseCase(propostaRepositoryMock.Object);            
            var resultado = await useCase.ExecuteAsync(propostaId);
            
            Assert.NotNull(resultado);
            Assert.Equal(propostaId, resultado.PropostaId);
            propostaRepositoryMock.Verify(repo => repo.GetStatusAsync(propostaId), Times.Once);
        }

        [Fact]
        public async Task ObtemProposta_DeveRetornarNull_QuandoNaoEncontrada()
        {            
            var propostaId = Guid.NewGuid();
            var propostaRepositoryMock = new Mock<IPropostaRepository>();
            
            propostaRepositoryMock.Setup(repo => repo.GetStatusAsync(propostaId)).ReturnsAsync((PropostaResponseDto?)null);

            var useCase = new ObtemPropostaUseCase(propostaRepositoryMock.Object);            
            var resultado = await useCase.ExecuteAsync(propostaId);
            
            Assert.Null(resultado);
            propostaRepositoryMock.Verify(repo => repo.GetStatusAsync(propostaId), Times.Once);
        }
    }
}