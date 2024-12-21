using System;
using System.Collections.Generic;
using GestaoAlojamentosApp.App.ViewModels;
using GestaoAlojamentosApp.Domain.Interfaces.Services;
using GestaoAlojamentosApp.Domain.Enums;

namespace GestaoAlojamentosApp.App.Controllers
{
    /// <summary>
    /// Controlador responsável pela gestão de check-ins
    /// Autor: Tiago Vale
    /// Email: a27675@alunos.ipca.pt
    /// Instituto: IPCA
    /// </summary>
    public class CheckInController
    {
        #region Atributos

        private readonly ICheckInService _checkInService;
        private readonly IReservaService _reservaService;

        #endregion

        #region Construtor

        /// <summary>
        /// Inicializa o controlador de check-ins com os serviços de check-in e reserva fornecidos.
        /// </summary>
        public CheckInController(ICheckInService checkInService, IReservaService reservaService)
        {
            _checkInService = checkInService ?? throw new ArgumentNullException(nameof(checkInService));
            _reservaService = reservaService ?? throw new ArgumentNullException(nameof(reservaService));
        }

        #endregion

        #region Métodos de Obtenção de Dados

        /// <summary>
        /// Obtém todos os check-ins registados.
        /// </summary>
        public List<CheckInViewModel> ObterTodosCheckIns()
        {
            try
            {
                var checkIns = _checkInService.ObterTodosCheckIns();
                var checkInsViewModel = new List<CheckInViewModel>();

                foreach (var checkIn in checkIns)
                {
                    var checkInViewModel = CheckInViewModel.DeCheckInParaViewModel(checkIn);
                    if (checkInViewModel != null)
                    {
                        checkInsViewModel.Add(checkInViewModel);
                    }
                }

                return checkInsViewModel;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Erro ao obter todos os check-ins: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Obtém um check-in pelo seu ID.
        /// </summary>
        public CheckInViewModel? ObterCheckInPorId(int id)
        {
            try
            {
                var checkIn = _checkInService.ObterCheckInPorId(id);
                if (checkIn == null)
                    return null;

                return CheckInViewModel.DeCheckInParaViewModel(checkIn);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Erro ao obter check-in por ID: {ex.Message}", ex);
            }
        }

        #endregion

        #region Métodos de Criação, Atualização e Remoção

        /// <summary>
        /// Cria um novo check-in baseado em uma reserva existente.
        /// </summary>
        public bool CriarCheckIn(int reservaId, DateTime dataHoraCheckIn, int numeroDeClientesPresentes)
        {
            try
            {
                var reserva = _reservaService.ObterReservaPorId(reservaId);
                if (reserva == null)
                {
                    throw new InvalidOperationException($"Reserva com ID {reservaId} não encontrada.");
                }

                return _checkInService.CriarCheckIn(reservaId, dataHoraCheckIn, numeroDeClientesPresentes);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Erro ao criar check-in: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Altera o status de um check-in.
        /// </summary>
        public bool AlterarStatusCheckIn(int id, StatusCheckIn status)
        {
            try
            {
                return _checkInService.AlterarStatusCheckIn(id, status);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Erro ao alterar status do check-in: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Remove um check-in pelo seu ID.
        /// </summary>
        public bool RemoverCheckIn(int id)
        {
            try
            {
                return _checkInService.RemoverCheckIn(id);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Erro ao remover check-in: {ex.Message}", ex);
            }
        }

        #endregion
    }
}
