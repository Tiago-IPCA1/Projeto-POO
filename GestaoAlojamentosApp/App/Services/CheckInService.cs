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
    /// Serviço responsável pela lógica de negócios relacionada ao processo de check-in.
    /// Implementa funcionalidades de criação, alteração de status, remoção e consulta de check-ins.
    /// Autor: Tiago Vale
    /// Email: a27675@alunos.ipca.pt
    /// Instituto: IPCA
    public class CheckInService : ICheckInService
    {
        private readonly ICheckInRepository _checkInRepository;
        private readonly ICheckInValidator _checkInValidator;
        private readonly IReservaService _reservaService;

        #region Construtor
        public CheckInService(ICheckInRepository checkInRepository, ICheckInValidator checkInValidator, IReservaService reservaService)
        {
            _checkInRepository = checkInRepository ?? throw new ArgumentNullException(nameof(checkInRepository));
            _checkInValidator = checkInValidator ?? throw new ArgumentNullException(nameof(checkInValidator));
            _reservaService = reservaService ?? throw new ArgumentNullException(nameof(reservaService));
        }
        #endregion

        #region Métodos de Criação e Atualização

        public bool CriarCheckIn(int reservaId, DateTime dataHoraCheckIn, int numeroDeClientesPresentes)
        {
            try
            {
                var reserva = _reservaService.ObterReservaPorId(reservaId);
                if (reserva == null)
                {
                    throw new InvalidOperationException($"Reserva com ID {reservaId} não encontrada.");
                }

                if (_checkInRepository.CheckInJaExiste(reservaId))
                {
                    throw new InvalidOperationException($"Já existe um check-in associado à reserva ID {reservaId}.");
                }

                var checkIn = new CheckIn(reservaId, dataHoraCheckIn, numeroDeClientesPresentes);

                _checkInValidator.ValidarCheckIn(checkIn);

                _checkInRepository.Adicionar(checkIn);
                return true;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Erro ao criar check-in: {ex.Message}", ex);
            }
        }

        public bool AlterarStatusCheckIn(int id, StatusCheckIn status)
        {
            try
            {
                var checkIn = _checkInRepository.ObterPorId(id);
                if (checkIn == null)
                {
                    throw new InvalidOperationException($"Check-in com ID {id} não encontrado.");  
                }

                checkIn.Status = status;
                _checkInRepository.Atualizar(checkIn);
                return true;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Erro ao alterar status do check-in: {ex.Message}", ex);
            }
        }

        #endregion

        #region Métodos de Remoção

        public bool RemoverCheckIn(int id)
        {
            try
            {
                var checkIn = _checkInRepository.ObterPorId(id);
                if (checkIn == null)
                {
                    throw new InvalidOperationException($"Check-in com ID {id} não encontrado.");  
                }

                _checkInRepository.Remover(id);
                return true;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Erro ao remover check-in: {ex.Message}", ex);
            }
        }

        #endregion

        #region Métodos de Consulta

        public CheckIn? ObterCheckInPorId(int id)
        {
            return _checkInRepository.ObterPorId(id);
        }

        public List<CheckIn> ObterCheckInsPorReserva(int reservaId)
        {
            return _checkInRepository.ObterCheckInsPorReserva(reservaId);
        }

        public List<CheckIn> ObterCheckInsPorStatus(StatusCheckIn status)
        {
            return _checkInRepository.ObterCheckInsPorStatus(status);
        }

        public List<CheckIn> ObterTodosCheckIns()
        {
            return _checkInRepository.ObterTodos();
        }

        #endregion

    }
}