using Moq;
using System;
using Xunit;
using GestaoAlojamentosApp.Domain.Models;
using GestaoAlojamentosApp.Domain.Enums;
using GestaoAlojamentosApp.Domain.Interfaces.Repositories;
using GestaoAlojamentosApp.Domain.Interfaces.Services;
using GestaoAlojamentosApp.Domain.Interfaces.Validators;
using GestaoAlojamentosApp.App.Services;

namespace GestaoAlojamentosApp.Tests
{   
    /// <summary>
    /// Classe respons�vel pelos testes unit�rios do servi�o AlojamentoService.
    /// Autor: Tiago Vale
    /// Email: a27675@alunos.ipca.pt
    /// Instituto: IPCA
    /// </summary>
    public class AlojamentoServiceTests
    {
        private readonly Mock<IAlojamentoRepository> _mockAlojamentoRepository;
        private readonly Mock<IAlojamentoValidator> _mockAlojamentoValidator;
        private readonly IAlojamentoService _alojamentoService;

        public AlojamentoServiceTests()
        {
            // Cria��o dos mocks para as depend�ncias
            _mockAlojamentoRepository = new Mock<IAlojamentoRepository>();
            _mockAlojamentoValidator = new Mock<IAlojamentoValidator>();

            // Instancia o servi�o com os mocks
            _alojamentoService = new AlojamentoService(
                _mockAlojamentoRepository.Object,
                _mockAlojamentoValidator.Object
            );
        }

        #region Testes de Cria��o

        [Fact]
        public void Adicionar_Sucesso()
        {
            // Arrange
            var nome = "Alojamento Teste";
            var localizacao = "Localiza��o Teste";
            var precoPorNoite = 100m;
            var capacidade = 4;
            var numeroDeQuartos = 2;
            var status = StatusAlojamento.Disponivel;
            var tipo = TipoAlojamento.Apartamento;

            var alojamento = new Alojamento(
                nome,
                localizacao,
                precoPorNoite,
                capacidade,
                numeroDeQuartos,
                status,
                tipo
            );

            // Configura o mock para a valida��o
            _mockAlojamentoValidator.Setup(v => v.ValidarAlojamento(It.IsAny<Alojamento>())).Returns(true);

            // Act
            var result = _alojamentoService.CriarAlojamento(
                nome,
                localizacao,
                precoPorNoite,
                capacidade,
                numeroDeQuartos,
                status,
                tipo
            );

            // Assert
            _mockAlojamentoValidator.Verify(v => v.ValidarAlojamento(It.IsAny<Alojamento>()), Times.Once);
            _mockAlojamentoRepository.Verify(r => r.Adicionar(It.IsAny<Alojamento>()), Times.Once);
            Assert.True(result);
        }

        [Fact]
        public void Adicionar_Excecao_Existe()
        {
            // Arrange
            var nome = "Alojamento Teste";
            var localizacao = "Localiza��o Teste";
            var precoPorNoite = 100m;
            var capacidade = 4;
            var numeroDeQuartos = 2;
            var status = StatusAlojamento.Disponivel;
            var tipo = TipoAlojamento.Apartamento;

            // Configura o mock para simular que o alojamento j� existe
            _mockAlojamentoRepository.Setup(r => r.ObterAlojamentoPorNome(nome))
                .Returns(new Alojamento(nome, localizacao, precoPorNoite, capacidade, numeroDeQuartos, status, tipo));

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _alojamentoService.CriarAlojamento(nome, localizacao, precoPorNoite, capacidade, numeroDeQuartos, status, tipo));
        }

        #endregion

        #region Testes de Atualiza��o

        [Fact]
        public void Atualizar_Sucesso()
        {
            // Arrange
            var id = 1;
            var nome = "Alojamento Atualizado";
            var localizacao = "Localiza��o Atualizada";
            var precoPorNoite = 150m;
            var capacidade = 5;
            var numeroDeQuartos = 3;
            var status = StatusAlojamento.Indisponivel;
            var tipo = TipoAlojamento.Casa;

            var alojamentoExistente = new Alojamento(
                "Alojamento Antigo",
                "Localiza��o Antiga",
                100m,
                4,
                2,
                StatusAlojamento.Disponivel,
                TipoAlojamento.Apartamento
            );

            // Configura o mock para retornar o alojamento existente
            _mockAlojamentoRepository.Setup(r => r.ObterPorId(id)).Returns(alojamentoExistente);
            _mockAlojamentoValidator.Setup(v => v.ValidarAlojamento(It.IsAny<Alojamento>())).Returns(true);

            // Act
            var result = _alojamentoService.AtualizarAlojamento(
                id,
                nome,
                localizacao,
                precoPorNoite,
                capacidade,
                numeroDeQuartos,
                status,
                tipo
            );

            // Assert
            _mockAlojamentoRepository.Verify(r => r.Atualizar(It.IsAny<Alojamento>()), Times.Once);
            Assert.True(result);
            Assert.Equal(nome, alojamentoExistente.Nome);
            Assert.Equal(status, alojamentoExistente.Status);
        }

        [Fact]
        public void Atualizar_Excecao_NaoExiste()
        {
            // Arrange
            var id = 999; // Um ID que n�o existe no reposit�rio
            var nome = "Alojamento Atualizado";
            var localizacao = "Localiza��o Atualizada";
            var precoPorNoite = 150m;
            var capacidade = 5;
            var numeroDeQuartos = 3;
            var status = StatusAlojamento.Indisponivel;
            var tipo = TipoAlojamento.Casa;

            // Configura o mock para retornar null (n�o encontrado)
            _mockAlojamentoRepository.Setup(r => r.ObterPorId(id)).Returns((Alojamento?)null);

            // Act & Assert
            Assert.Throws<KeyNotFoundException>(() => _alojamentoService.AtualizarAlojamento(id, nome, localizacao, precoPorNoite, capacidade, numeroDeQuartos, status, tipo));
        }

        #endregion

        #region Testes de Remo��o

        [Fact]
        public void Remover_Sucesso()
        {
            // Arrange
            var id = 1;
            var alojamentoExistente = new Alojamento("Alojamento Teste", "Localiza��o Teste", 100m, 4, 2, StatusAlojamento.Disponivel, TipoAlojamento.Apartamento);

            // Configura o mock para retornar o alojamento existente
            _mockAlojamentoRepository.Setup(r => r.ObterPorId(id)).Returns(alojamentoExistente);

            // Act
            var result = _alojamentoService.RemoverAlojamento(id);

            // Assert
            _mockAlojamentoRepository.Verify(r => r.Remover(id), Times.Once);
            Assert.True(result);
        }

        [Fact]
        public void Remover_Excecao_NaoExiste()
        {
            // Arrange
            var id = 999; // Um ID que n�o existe no reposit�rio

            // Configura o mock para retornar null (n�o encontrado)
            _mockAlojamentoRepository.Setup(r => r.ObterPorId(id)).Returns((Alojamento?)null);

            // Act & Assert
            Assert.Throws<KeyNotFoundException>(() => _alojamentoService.RemoverAlojamento(id));
        }

        #endregion
    }
}
