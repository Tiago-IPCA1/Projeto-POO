using System;
using GestaoAlojamentosApp.Domain.Models;
using GestaoAlojamentosApp.Domain.Interfaces.Repositories;
using GestaoAlojamentosApp.Domain.Interfaces.Validators;

namespace GestaoAlojamentosApp.Domain.Validators
{
    /// <summary>
    /// Classe responsável pela validação dos dados de reserva.
    /// Autor: Tiago Vale
    /// Email: a27675@alunos.ipca.pt
    /// Instituto: IPCA
    /// </summary>
    public class ReservaValidator : IReservaValidator
    {
        private readonly IReservaRepository _reservaRepository;
        private readonly IAlojamentoRepository _alojamentoRepository;
        private readonly IClienteRepository _clienteRepository;

        #region Construtor

        public ReservaValidator(IReservaRepository reservaRepository, IAlojamentoRepository alojamentoRepository, IClienteRepository clienteRepository)
        {
            _reservaRepository = reservaRepository ?? throw new ArgumentNullException(nameof(reservaRepository));
            _alojamentoRepository = alojamentoRepository ?? throw new ArgumentNullException(nameof(alojamentoRepository));
            _clienteRepository = clienteRepository ?? throw new ArgumentNullException(nameof(clienteRepository));
        }

        #endregion

        #region Métodos de Validação

        public bool ValidarCliente(int clienteId)
        {
            var cliente = _clienteRepository.ObterPorId(clienteId);
            if (cliente == null)
                throw new KeyNotFoundException($"Cliente com ID {clienteId} não encontrado.");
            return true;
        }

        public bool ValidarAlojamento(int alojamentoId)
        {
            var alojamento = _alojamentoRepository.ObterPorId(alojamentoId);
            if (alojamento == null)
                throw new KeyNotFoundException($"Alojamento com ID {alojamentoId} não encontrado.");
            return true;
        }

        public bool ValidarDatas(DateTime dataInicio, DateTime dataFim)
        {
            if ((dataFim - dataInicio).Days <= 0)
                throw new ArgumentException("A data de término deve ser posterior à data de início.");
            return true;
        }

        public bool ValidarNumeroDePessoas(int alojamentoId, int numeroDePessoas)
        {
            var alojamento = _alojamentoRepository.ObterPorId(alojamentoId);
            if (alojamento == null)
                throw new KeyNotFoundException($"Alojamento com ID {alojamentoId} não encontrado.");

            if (numeroDePessoas <= 0 || numeroDePessoas > alojamento.Capacidade)
                throw new ArgumentException("Número de pessoas não pode exceder a capacidade do alojamento.");
            return true;
        }

        public bool ValidarReserva(int clienteId, int alojamentoId, DateTime dataInicio, DateTime dataFim, int numeroDePessoas)
        {
            // Validação do Cliente
            ValidarCliente(clienteId);

            // Validação do Alojamento
            ValidarAlojamento(alojamentoId);

            // Validação das Datas
            ValidarDatas(dataInicio, dataFim);

            // Validação do número de pessoas
            ValidarNumeroDePessoas(alojamentoId, numeroDePessoas);

            return true;
        }

        #endregion
    }
}
