using System;
using System.Collections.Generic;
using GestaoAlojamentosApp.Domain.Models;
using GestaoAlojamentosApp.Domain.Interfaces.Repositories;
using GestaoAlojamentosApp.Domain.Interfaces.Validators;
using GestaoAlojamentosApp.Domain.Interfaces.Services;
using GestaoAlojamentosApp.Domain.Enums;

namespace GestaoAlojamentosApp.App.Services
{
    /// <summary>
    /// Serviço responsável pela lógica de negócios relacionada à gestão de reservas.
    /// Implementa funcionalidades de criação, atualização, remoção, consulta, alteração de status.
    /// Autor: Tiago Vale
    /// Email: a27675@alunos.ipca.pt
    /// Instituto: IPCA
    /// </summary>
    public class ReservaService : IReservaService
    {
        private readonly IReservaRepository _reservaRepository;
        private readonly IAlojamentoRepository _alojamentoRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IReservaValidator _reservaValidator;

        #region Construtor

        public ReservaService(IReservaRepository reservaRepository,
            IAlojamentoRepository alojamentoRepository,
            IClienteRepository clienteRepository,
            IReservaValidator reservaValidator)
        {
            _reservaRepository = reservaRepository ?? throw new ArgumentNullException(nameof(reservaRepository));
            _alojamentoRepository = alojamentoRepository ?? throw new ArgumentNullException(nameof(alojamentoRepository));
            _clienteRepository = clienteRepository ?? throw new ArgumentNullException(nameof(clienteRepository));
            _reservaValidator = reservaValidator ?? throw new ArgumentNullException(nameof(reservaValidator));
        }

        #endregion

        #region Métodos de Cálculo de Preço

        private decimal CalcularPrecoTotal(int numeroNoites, decimal precoPorNoite)
        {
            return numeroNoites * precoPorNoite;
        }

        #endregion

        #region Métodos de Criação e Atualização

        public bool CriarReserva(int clienteId, int alojamentoId, DateTime dataInicio, DateTime dataFim, decimal precoTotal, int numeroDePessoas)
        {
            // Obtenha o cliente e o alojamento utilizando os IDs fornecidos
            var (cliente, alojamento) = ObterClienteEAlojamento(clienteId, alojamentoId);

            // Verifique se o alojamento está disponível
            if (alojamento.Status != StatusAlojamento.Disponivel)
                throw new InvalidOperationException("O alojamento não está disponível para reserva.");

            // Validação da reserva com os IDs
            _reservaValidator.ValidarReserva(clienteId, alojamentoId, dataInicio, dataFim, numeroDePessoas);

            // Cálculo do preço total
            int numeroNoites = (dataFim - dataInicio).Days;
            decimal precoTotalCalculado = CalcularPrecoTotal(numeroNoites, alojamento.PrecoPorNoite);

            // Criação da reserva
            var reserva = new Reserva(clienteId, alojamentoId, dataInicio, dataFim, precoTotalCalculado, numeroDePessoas);
            _reservaRepository.Adicionar(reserva);
            return true;
        }

        public bool AtualizarReserva(int id, int clienteId, int alojamentoId, DateTime dataInicio, DateTime dataFim, decimal precoTotal, int numeroDePessoas)
        {
            // Obtenha a reserva pelo ID
            var reserva = _reservaRepository.ObterPorId(id);
            if (reserva == null)
                throw new KeyNotFoundException($"Reserva com ID {id} não encontrada.");

            // Obtenha o cliente e o alojamento utilizando os IDs fornecidos
            var (cliente, alojamento) = ObterClienteEAlojamento(clienteId, alojamentoId);

            // Verifique se o alojamento está disponível
            if (alojamento.Status != StatusAlojamento.Disponivel)
                throw new InvalidOperationException("O alojamento não está disponível para reserva.");

            // Validação da reserva com os IDs
            _reservaValidator.ValidarReserva(clienteId, alojamentoId, dataInicio, dataFim, numeroDePessoas);

            // Cálculo do preço total
            int numeroNoites = (dataFim - dataInicio).Days;
            decimal precoTotalCalculado = CalcularPrecoTotal(numeroNoites, alojamento.PrecoPorNoite);

            // Atualize os dados da reserva
            reserva.ClienteId = clienteId;
            reserva.AlojamentoId = alojamentoId;
            reserva.DataInicio = dataInicio;
            reserva.DataFim = dataFim;
            reserva.PrecoTotal = precoTotalCalculado;
            reserva.NumeroDePessoas = numeroDePessoas;

            _reservaRepository.Atualizar(reserva);
            return true;
        }

        #endregion

        #region Métodos Auxiliares

        private (Cliente cliente, Alojamento alojamento) ObterClienteEAlojamento(int clienteId, int alojamentoId)
        {
            var cliente = _clienteRepository.ObterPorId(clienteId);
            if (cliente == null)
                throw new KeyNotFoundException($"Cliente com ID {clienteId} não encontrado.");

            var alojamento = _alojamentoRepository.ObterPorId(alojamentoId);
            if (alojamento == null)
                throw new KeyNotFoundException($"Alojamento com ID {alojamentoId} não encontrado.");

            return (cliente, alojamento);
        }

        #endregion

        #region Métodos de Remoção

        public bool RemoverReserva(int id)
        {
            var reserva = _reservaRepository.ObterPorId(id);
            if (reserva == null)
                throw new KeyNotFoundException($"Reserva com ID {id} não encontrada.");

            _reservaRepository.Remover(id);
            return true;
        }

        #endregion

        #region Métodos de Alteração de Status

        public bool AlterarStatusReserva(int id, StatusReserva status)
        {
            var reserva = _reservaRepository.ObterPorId(id);
            if (reserva == null)
                throw new KeyNotFoundException($"Reserva com ID {id} não encontrada.");

            reserva.Status = status;
            _reservaRepository.AtualizarStatus(id, status);
            return true;
        }

        #endregion

        #region Métodos de Consultas

        public List<Reserva> ObterTodasReservas()
        {
            return _reservaRepository.ObterTodos();
        }

        public Reserva? ObterReservaPorId(int id)
        {
            var reserva = _reservaRepository.ObterPorId(id);
            if (reserva == null)
                throw new KeyNotFoundException($"Reserva com ID {id} não encontrada.");
            return reserva;
        }

        public List<Reserva> ObterReservasPorCliente(int clienteId)
        {
            return _reservaRepository.ObterReservasPorCliente(clienteId);
        }

        public List<Reserva> ObterReservasPorAlojamento(int alojamentoId)
        {
            return _reservaRepository.ObterReservasPorAlojamento(alojamentoId);
        }

        public List<Reserva> ObterReservasDisponiveis(DateTime dataInicio, DateTime dataFim)
        {
            if (dataFim <= dataInicio)
                throw new ArgumentException("A data de término não pode ser anterior ou igual à data de início.");

            return _reservaRepository.ObterReservasDisponiveis(dataInicio, dataFim);
        }

        public List<Reserva> ObterReservasPorStatus(StatusReserva status)
        {
            return _reservaRepository.ObterPorStatus(status);
        }

        #endregion
    }
}
