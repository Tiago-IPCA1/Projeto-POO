using Moq;
using System;
using System.Collections.Generic;
using GestaoAlojamentosApp.Domain.Models;
using GestaoAlojamentosApp.Domain.Enums;
using GestaoAlojamentosApp.Domain.Interfaces.Repositories;
using GestaoAlojamentosApp.Domain.Interfaces.Services;
using GestaoAlojamentosApp.Domain.Interfaces.Validators;
using GestaoAlojamentosApp.App.Services;
using Xunit;

namespace GestaoAlojamentosApp.Tests
{
    /// <summary>
    /// Classe responsável pelos testes unitários do serviço PagamentoService.
    /// Autor: Tiago Vale
    /// Email: a27675@alunos.ipca.pt
    /// Instituto: IPCA
    /// </summary>
    public class PagamentoServiceTests
    {
        private readonly Mock<IPagamentoRepository> _mockPagamentoRepository;
        private readonly Mock<IReservaRepository> _mockReservaRepository;
        private readonly Mock<IPagamentoValidator> _mockPagamentoValidator;
        private readonly IPagamentoService _pagamentoService;

        public PagamentoServiceTests()
        {
            _mockPagamentoRepository = new Mock<IPagamentoRepository>();
            _mockReservaRepository = new Mock<IReservaRepository>();
            _mockPagamentoValidator = new Mock<IPagamentoValidator>();

            _pagamentoService = new PagamentoService(
                _mockPagamentoRepository.Object,
                _mockReservaRepository.Object,
                _mockPagamentoValidator.Object
            );
        }

        #region Testes de Criação

        [Fact]
        public void CriarPagamento_Excecao_ReservaNaoExistente()
        {
            var reservaId = 1;
            var valor = 150.50m;
            var metodoPagamento = MetodoPagamento.CartaoCredito;
            var status = StatusPagamento.Confirmado;
            var dataPagamento = DateTime.Now;

            _mockReservaRepository.Setup(r => r.ObterPorId(reservaId)).Returns((Reserva?)null);

            var exception = Assert.Throws<KeyNotFoundException>(() => _pagamentoService.CriarPagamento(reservaId, valor, metodoPagamento, status, dataPagamento));
            Assert.Equal($"A reserva com ID {reservaId} não foi encontrada.", exception.Message);
        }

        [Fact]
        public void CriarPagamento_Excecao_ValorInvalido()
        {
            var reservaId = 1;
            var valor = -150.50m;
            var metodoPagamento = MetodoPagamento.CartaoCredito;
            var status = StatusPagamento.Confirmado;
            var dataPagamento = DateTime.Now;

            var exception = Assert.Throws<ArgumentException>(() => _pagamentoService.CriarPagamento(reservaId, valor, metodoPagamento, status, dataPagamento));
            Assert.Equal("O valor do pagamento deve ser maior que zero.", exception.Message);
        }

        [Fact]
        public void CriarPagamento_Excecao_StatusInvalido()
        {
            var reservaId = 1;
            var valor = 150.50m;
            var metodoPagamento = MetodoPagamento.CartaoCredito;
            var status = (StatusPagamento)999; // Status inválido
            var dataPagamento = DateTime.Now;

            var exception = Assert.Throws<ArgumentException>(() => _pagamentoService.CriarPagamento(reservaId, valor, metodoPagamento, status, dataPagamento));
            Assert.Equal("Status de pagamento inválido.", exception.Message);
        }

        #endregion

        #region Testes de Remoção

        [Fact]
        public void RemoverPagamento_Excecao_NaoExistente()
        {
            var id = 999;
            _mockPagamentoRepository.Setup(r => r.ObterPorId(id)).Returns((Pagamento?)null);

            var exception = Assert.Throws<KeyNotFoundException>(() => _pagamentoService.RemoverPagamentoPorId(id));
            Assert.Equal($"Pagamento com ID {id} não encontrado.", exception.Message);
        }

        #endregion
    }
}
