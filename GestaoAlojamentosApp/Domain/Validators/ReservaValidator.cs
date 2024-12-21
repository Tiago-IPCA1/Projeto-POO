using System;
using GestaoAlojamentosApp.Domain.Models;
using GestaoAlojamentosApp.Domain.Interfaces.Repositories;
using GestaoAlojamentosApp.Domain.Interfaces.Validators;

namespace GestaoAlojamentosApp.Domain.Validators
{
    /// <summary>
    /// Classe respons�vel pela valida��o dos dados de reserva.
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

        #region M�todos de Valida��o

        public bool ValidarCliente(int clienteId)
        {
            var cliente = _clienteRepository.ObterPorId(clienteId);
            if (cliente == null)
                throw new KeyNotFoundException($"Cliente com ID {clienteId} n�o encontrado.");
            return true;
        }

        public bool ValidarAlojamento(int alojamentoId)
        {
            var alojamento = _alojamentoRepository.ObterPorId(alojamentoId);
            if (alojamento == null)
                throw new KeyNotFoundException($"Alojamento com ID {alojamentoId} n�o encontrado.");
            return true;
        }

        public bool ValidarDatas(DateTime dataInicio, DateTime dataFim)
        {
            if ((dataFim - dataInicio).Days <= 0)
                throw new ArgumentException("A data de t�rmino deve ser posterior � data de in�cio.");
            return true;
        }

        public bool ValidarNumeroDePessoas(int alojamentoId, int numeroDePessoas)
        {
            var alojamento = _alojamentoRepository.ObterPorId(alojamentoId);
            if (alojamento == null)
                throw new KeyNotFoundException($"Alojamento com ID {alojamentoId} n�o encontrado.");

            if (numeroDePessoas <= 0 || numeroDePessoas > alojamento.Capacidade)
                throw new ArgumentException("N�mero de pessoas n�o pode exceder a capacidade do alojamento.");
            return true;
        }

        public bool ValidarReserva(int clienteId, int alojamentoId, DateTime dataInicio, DateTime dataFim, int numeroDePessoas)
        {
            // Valida��o do Cliente
            ValidarCliente(clienteId);

            // Valida��o do Alojamento
            ValidarAlojamento(alojamentoId);

            // Valida��o das Datas
            ValidarDatas(dataInicio, dataFim);

            // Valida��o do n�mero de pessoas
            ValidarNumeroDePessoas(alojamentoId, numeroDePessoas);

            return true;
        }

        #endregion
    }
}
