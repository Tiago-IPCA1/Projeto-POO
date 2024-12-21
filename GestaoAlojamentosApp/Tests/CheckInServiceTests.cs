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
    /// Classe responsável pelos testes unitários do serviço CheckInService.
    /// Autor: Tiago Vale
    /// Email: a27675@alunos.ipca.pt
    /// Instituto: IPCA
    /// </summary>
    public class CheckInServiceTests
    {
        private readonly Mock<ICheckInRepository> _mockCheckInRepository;
        private readonly Mock<ICheckInValidator> _mockCheckInValidator;
        private readonly Mock<IReservaService> _mockReservaService;
        private readonly ICheckInService _checkInService;

        public CheckInServiceTests()
        {
            _mockCheckInRepository = new Mock<ICheckInRepository>();
            _mockCheckInValidator = new Mock<ICheckInValidator>();
            _mockReservaService = new Mock<IReservaService>();

            _checkInService = new CheckInService(
                _mockCheckInRepository.Object,
                _mockCheckInValidator.Object,
                _mockReservaService.Object
            );
        }

        #region Testes de Criação

        [Fact]
        public void Criar_Sucesso()
        {
            var reservaId = 1;
            var dataHoraCheckIn = DateTime.Now;
            var numeroDeClientesPresentes = 2;

            var cliente = new Cliente("Cliente Exemplo", "cliente@exemplo.com", "12345678901", 30);
            var alojamento = new Alojamento("Alojamento Exemplo", "Descrição Alojamento", 100.00m, 2, 1, StatusAlojamento.Disponivel, TipoAlojamento.Hotel);

            var reserva = new Reserva(cliente.Id, alojamento.Id, DateTime.Now, DateTime.Now.AddDays(1), 100.00m, 2); 

            _mockReservaService.Setup(r => r.ObterReservaPorId(reservaId)).Returns(reserva);
            _mockCheckInRepository.Setup(r => r.CheckInJaExiste(reservaId)).Returns(false);
            _mockCheckInValidator.Setup(v => v.ValidarCheckIn(It.IsAny<CheckIn>())).Verifiable();

            var result = _checkInService.CriarCheckIn(reservaId, dataHoraCheckIn, numeroDeClientesPresentes);

            _mockCheckInValidator.Verify(v => v.ValidarCheckIn(It.IsAny<CheckIn>()), Times.Once);
            _mockCheckInRepository.Verify(r => r.Adicionar(It.IsAny<CheckIn>()), Times.Once);
            Assert.True(result);
        }

        [Fact]
        public void Criar_Excecao_ReservaNaoEncontrada()
        {
            var reservaId = 1;
            _mockReservaService.Setup(r => r.ObterReservaPorId(reservaId)).Returns((Reserva?)null);

            Assert.Throws<InvalidOperationException>(() => _checkInService.CriarCheckIn(reservaId, DateTime.Now, 2));
        }

        [Fact]
        public void Criar_Excecao_JaExiste()
        {
            var reservaId = 1;
            var dataHoraCheckIn = DateTime.Now;
            var numeroDeClientesPresentes = 2;

            var cliente = new Cliente("Cliente Exemplo", "cliente@exemplo.com", "12345678901", 30);
            var alojamento = new Alojamento("Alojamento Exemplo", "Descrição Alojamento", 100.00m, 2, 1, StatusAlojamento.Disponivel, TipoAlojamento.Hotel);

            var reserva = new Reserva(cliente.Id, alojamento.Id, DateTime.Now, DateTime.Now.AddDays(1), 100.00m, 2); 
            _mockReservaService.Setup(r => r.ObterReservaPorId(reservaId)).Returns(reserva);
            _mockCheckInRepository.Setup(r => r.CheckInJaExiste(reservaId)).Returns(true);

            Assert.Throws<InvalidOperationException>(() => _checkInService.CriarCheckIn(reservaId, dataHoraCheckIn, numeroDeClientesPresentes));
        }

        #endregion

        #region Testes de Atualização de Status

        [Fact]
        public void AlterarStatus_Sucesso()
        {
            var checkInId = 1;
            var status = StatusCheckIn.Realizado;

            var checkIn = new CheckIn(checkInId, DateTime.Now, 2);
            _mockCheckInRepository.Setup(r => r.ObterPorId(checkInId)).Returns(checkIn);

            var result = _checkInService.AlterarStatusCheckIn(checkInId, status);

            _mockCheckInRepository.Verify(r => r.Atualizar(It.IsAny<CheckIn>()), Times.Once);
            Assert.True(result);
            Assert.Equal(status, checkIn.Status);
        }

        [Fact]
        public void AlterarStatus_Excecao_NaoExiste()
        {
            var checkInId = 1;
            var status = StatusCheckIn.Realizado;
            _mockCheckInRepository.Setup(r => r.ObterPorId(checkInId)).Returns((CheckIn?)null);

            Assert.Throws<InvalidOperationException>(() => _checkInService.AlterarStatusCheckIn(checkInId, status));
        }

        #endregion

        #region Testes de Remoção

        [Fact]
        public void Remover_Sucesso()
        {
            var checkInId = 1;
            var checkIn = new CheckIn(checkInId, DateTime.Now, 2);
            _mockCheckInRepository.Setup(r => r.ObterPorId(checkInId)).Returns(checkIn);

            var result = _checkInService.RemoverCheckIn(checkInId);

            _mockCheckInRepository.Verify(r => r.Remover(checkInId), Times.Once);
            Assert.True(result);
        }

        [Fact]
        public void Remover_Excecao_NaoExiste()
        {
            var checkInId = 1;
            _mockCheckInRepository.Setup(r => r.ObterPorId(checkInId)).Returns((CheckIn?)null);

            Assert.Throws<InvalidOperationException>(() => _checkInService.RemoverCheckIn(checkInId));
        }

        #endregion
    }
}
