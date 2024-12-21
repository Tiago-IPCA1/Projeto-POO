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
    /// Classe responsável pelos testes unitários do serviço ReservaService.
    /// Autor: Tiago Vale
    /// Email: a27675@alunos.ipca.pt
    /// Instituto: IPCA
    /// </summary>
    public class ReservaServiceTests
    {
        private readonly Mock<IReservaRepository> _mockReservaRepository;
        private readonly Mock<IAlojamentoRepository> _mockAlojamentoRepository;
        private readonly Mock<IClienteRepository> _mockClienteRepository;
        private readonly Mock<IReservaValidator> _mockReservaValidator;
        private readonly IReservaService _reservaService;

        public ReservaServiceTests()
        {
            _mockReservaRepository = new Mock<IReservaRepository>();
            _mockAlojamentoRepository = new Mock<IAlojamentoRepository>();
            _mockClienteRepository = new Mock<IClienteRepository>();
            _mockReservaValidator = new Mock<IReservaValidator>();

            _reservaService = new ReservaService(
                _mockReservaRepository.Object,
                _mockAlojamentoRepository.Object,
                _mockClienteRepository.Object,
                _mockReservaValidator.Object
            );
        }

        #region Testes de Criação de Reserva

        [Fact]
        public void CriarReserva_Sucesso()
        {
            // Arrange
            var clienteId = 1;
            var alojamentoId = 1;
            var dataInicio = new DateTime(2024, 12, 1);
            var dataFim = new DateTime(2024, 12, 5);
            var numeroDePessoas = 2;

            var cliente = new Cliente("Cliente Teste", "email@test.com", "123456789", 30);
            var alojamento = new Alojamento("Alojamento Teste", "Localização Teste", 100m, 4, 2, StatusAlojamento.Disponivel, TipoAlojamento.Apartamento);

            _mockClienteRepository.Setup(c => c.ObterPorId(clienteId)).Returns(cliente);
            _mockAlojamentoRepository.Setup(a => a.ObterPorId(alojamentoId)).Returns(alojamento);
            _mockReservaValidator.Setup(v => v.ValidarReserva(clienteId, alojamentoId, dataInicio, dataFim, numeroDePessoas));
            _mockReservaRepository.Setup(r => r.Adicionar(It.IsAny<Reserva>()));

            // Act
            var resultado = _reservaService.CriarReserva(clienteId, alojamentoId, dataInicio, dataFim, 0, numeroDePessoas);

            // Assert
            _mockReservaValidator.Verify(v => v.ValidarReserva(clienteId, alojamentoId, dataInicio, dataFim, numeroDePessoas), Times.Once);
            _mockReservaRepository.Verify(r => r.Adicionar(It.IsAny<Reserva>()), Times.Once);
            Assert.True(resultado);
        }

        [Fact]
        public void CriarReserva_LancarExcecao_QuandoAlojamentoIndisponivel()
        {
            // Arrange
            var clienteId = 1;
            var alojamentoId = 1;
            var dataInicio = new DateTime(2024, 12, 1);
            var dataFim = new DateTime(2024, 12, 5);
            var numeroDePessoas = 2;

            var cliente = new Cliente("Cliente Teste", "email@test.com", "123456789", 30);
            var alojamento = new Alojamento("Alojamento Teste", "Localização Teste", 100m, 4, 2, StatusAlojamento.Indisponivel, TipoAlojamento.Apartamento);

            _mockClienteRepository.Setup(c => c.ObterPorId(clienteId)).Returns(cliente);
            _mockAlojamentoRepository.Setup(a => a.ObterPorId(alojamentoId)).Returns(alojamento);

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() =>
                _reservaService.CriarReserva(clienteId, alojamentoId, dataInicio, dataFim, 0, numeroDePessoas));
        }

        #endregion

        #region Testes de Atualização de Reserva

        [Fact]
        public void AtualizarReserva_Sucesso()
        {
            // Arrange
            var reservaId = 1;
            var clienteId = 1;
            var alojamentoId = 1;
            var dataInicio = new DateTime(2024, 12, 1);
            var dataFim = new DateTime(2024, 12, 5);
            var numeroDePessoas = 2;

            var cliente = new Cliente("Cliente Teste", "email@test.com", "123456789", 30);
            var alojamento = new Alojamento("Alojamento Teste", "Localização Teste", 100m, 4, 2, StatusAlojamento.Disponivel, TipoAlojamento.Apartamento);
            var reservaExistente = new Reserva(clienteId, alojamentoId, dataInicio, dataFim, 400m, numeroDePessoas);

            _mockReservaRepository.Setup(r => r.ObterPorId(reservaId)).Returns(reservaExistente);
            _mockClienteRepository.Setup(c => c.ObterPorId(clienteId)).Returns(cliente);
            _mockAlojamentoRepository.Setup(a => a.ObterPorId(alojamentoId)).Returns(alojamento);
            _mockReservaValidator.Setup(v => v.ValidarReserva(clienteId, alojamentoId, dataInicio, dataFim, numeroDePessoas));

            // Act
            var resultado = _reservaService.AtualizarReserva(reservaId, clienteId, alojamentoId, dataInicio, dataFim, 0, numeroDePessoas);

            // Assert
            _mockReservaRepository.Verify(r => r.Atualizar(It.IsAny<Reserva>()), Times.Once);
            Assert.True(resultado);
        }

        [Fact]
        public void AtualizarReserva_LancarExcecao_QuandoReservaNaoExistir()
        {
            // Arrange
            var reservaId = 999;

            _mockReservaRepository.Setup(r => r.ObterPorId(reservaId)).Returns((Reserva?)null);

            // Act & Assert
            Assert.Throws<KeyNotFoundException>(() => _reservaService.AtualizarReserva(reservaId, 1, 1, DateTime.Now, DateTime.Now.AddDays(3), 0, 2));
        }

        #endregion

        #region Testes de Remoção de Reserva

        [Fact]
        public void RemoverReserva_Sucesso()
        {
            // Arrange
            var reservaId = 1;
            var reservaExistente = new Reserva(1, 1, DateTime.Now, DateTime.Now.AddDays(3), 300m, 2);

            _mockReservaRepository.Setup(r => r.ObterPorId(reservaId)).Returns(reservaExistente);

            // Act
            var resultado = _reservaService.RemoverReserva(reservaId);

            // Assert
            _mockReservaRepository.Verify(r => r.Remover(reservaId), Times.Once);
            Assert.True(resultado);
        }

        [Fact]
        public void RemoverReserva_LancarExcecao_QuandoReservaNaoExistir()
        {
            // Arrange
            var reservaId = 999;

            _mockReservaRepository.Setup(r => r.ObterPorId(reservaId)).Returns((Reserva?)null);

            // Act & Assert
            Assert.Throws<KeyNotFoundException>(() => _reservaService.RemoverReserva(reservaId));
        }

        #endregion
    }
}
