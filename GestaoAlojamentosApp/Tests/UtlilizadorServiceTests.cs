using Moq;
using System;
using System.Collections.Generic;
using Xunit;
using GestaoAlojamentosApp.Domain.Models;
using GestaoAlojamentosApp.Domain.Enums;
using GestaoAlojamentosApp.Domain.Interfaces.Repositories;
using GestaoAlojamentosApp.Domain.Interfaces.Services;
using GestaoAlojamentosApp.App.Services;

namespace GestaoAlojamentosApp.Tests
{
    /// <summary>
    /// Classe responsável pelos testes unitários do serviço UtilizadorService.
    /// Autor: Tiago Vale
    /// Email: a27675@alunos.ipca.pt
    /// Instituto: IPCA
    /// </summary>
    public class UtilizadorServiceTests
    {
        private readonly Mock<IUtilizadorRepository> _mockUtilizadorRepository;
        private readonly IUtilizadorService _utilizadorService;

        public UtilizadorServiceTests()
        {
            // Criação do mock para o repositório de utilizador
            _mockUtilizadorRepository = new Mock<IUtilizadorRepository>();

            _utilizadorService = new UtilizadorService(_mockUtilizadorRepository.Object);
        }

        #region Testes de Criação

        [Fact]
        public void CriarUtilizador_Sucesso()
        {
            // Arrange
            var utilizador = new Utilizador("admin", "admin123", TipoUtilizador.Administrador, 1);

            // Configura o mock para simular que o utilizador não existe
            _mockUtilizadorRepository.Setup(r => r.ObterUtilizadorPorUsername(utilizador.Username)).Returns((Utilizador?)null);
            _mockUtilizadorRepository.Setup(r => r.Adicionar(It.IsAny<Utilizador>())).Verifiable();

            // Act
            _utilizadorService.CriarUtilizador(utilizador);

            // Assert
            _mockUtilizadorRepository.Verify(r => r.Adicionar(It.IsAny<Utilizador>()), Times.Once);
        }

        [Fact]
        public void CriarUtilizador_Excecao_UsernameJaExistente()
        {
            // Arrange
            var utilizador = new Utilizador("admin", "admin123", TipoUtilizador.Administrador, 1);

            // Configura o mock para simular que o utilizador já existe
            _mockUtilizadorRepository.Setup(r => r.ObterUtilizadorPorUsername(utilizador.Username)).Returns(utilizador);

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => _utilizadorService.CriarUtilizador(utilizador));
        }

        #endregion

        #region Testes de Atualização

        [Fact]
        public void AtualizarUtilizador_Sucesso()
        {
            // Arrange
            var utilizador = new Utilizador("admin", "admin123", TipoUtilizador.Administrador, 1);
            _mockUtilizadorRepository.Setup(r => r.ObterUtilizadorPorId(utilizador.Id)).Returns(utilizador);
            _mockUtilizadorRepository.Setup(r => r.Atualizar(It.IsAny<Utilizador>())).Verifiable();

            // Act
            _utilizadorService.AtualizarUtilizador(utilizador);

            // Assert
            _mockUtilizadorRepository.Verify(r => r.Atualizar(It.IsAny<Utilizador>()), Times.Once);
        }

        [Fact]
        public void AtualizarUtilizador_Excecao_UtilizadorNaoExistente()
        {
            // Arrange
            var id = Guid.NewGuid(); 
            _mockUtilizadorRepository.Setup(r => r.ObterUtilizadorPorId(id)).Returns((Utilizador?)null);  

            // Act & Assert
            var exception = Assert.Throws<KeyNotFoundException>(() => _utilizadorService.AtualizarUtilizador(new Utilizador("", "", TipoUtilizador.Administrador, 1)));
            Assert.Equal("Utilizador não encontrado.", exception.Message);  
        }

        #endregion

        #region Testes de Remoção

        [Fact]
        public void ExcluirUtilizador_Sucesso()
        {
            // Arrange
            var id = Guid.NewGuid();  
            var utilizador = new Utilizador("admin", "admin123", TipoUtilizador.Administrador, 1);

            // Configura o mock para retornar o utilizador
            _mockUtilizadorRepository.Setup(r => r.ObterUtilizadorPorId(id)).Returns(utilizador);
            _mockUtilizadorRepository.Setup(r => r.Remover(It.IsAny<Guid>())).Verifiable();  

            // Act
            _utilizadorService.ExcluirUtilizador(id);

            // Assert
            _mockUtilizadorRepository.Verify(r => r.Remover(It.IsAny<Guid>()), Times.Once);
        }

        [Fact]
        public void ExcluirUtilizador_Excecao_UtilizadorNaoExistente()
        {
            // Arrange
            var id = Guid.NewGuid();  
            _mockUtilizadorRepository.Setup(r => r.ObterUtilizadorPorId(id)).Returns((Utilizador?)null);

            // Act & Assert
            Assert.Throws<KeyNotFoundException>(() => _utilizadorService.ExcluirUtilizador(id));
        }

        #endregion

        #region Testes de Leitura

        [Fact]
        public void ObterUtilizadorPorId_Sucesso()
        {
            // Arrange
            var id = Guid.NewGuid();  
            var utilizador = new Utilizador("admin", "admin123", TipoUtilizador.Administrador, 1);

            // Configura o mock para retornar o utilizador
            _mockUtilizadorRepository.Setup(r => r.ObterUtilizadorPorId(id)).Returns(utilizador);

            // Act
            var resultado = _utilizadorService.ObterUtilizadorPorId(id);

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal("admin", resultado?.Username);
        }

        #endregion
    }
}
