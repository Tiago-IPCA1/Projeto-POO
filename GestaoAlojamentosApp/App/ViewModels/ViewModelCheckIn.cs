using System;
using GestaoAlojamentosApp.Domain.Models;
using GestaoAlojamentosApp.Domain.Enums;

namespace GestaoAlojamentosApp.App.ViewModels
{
    /// <summary>
    /// Classe responsável por representar o modelo de dados de um check-in.
    /// Autor: Tiago Vale
    /// Email: a27675@alunos.ipca.pt
    /// Instituto: IPCA
    /// </summary>
    public class CheckInViewModel
    {
        #region Propriedades

        public int Id { get; set; }
        public int ReservaId { get; set; }
        public DateTime DataHoraCheckIn { get; set; }
        public int NumeroDeClientesPresentes { get; set; }
        public StatusCheckIn Status { get; set; }

        #endregion

        #region Métodos de Conversão

        public static CheckInViewModel? DeCheckInParaViewModel(CheckIn checkIn)
        {
            if (checkIn == null)
                return null;

            return new CheckInViewModel
            {
                Id = checkIn.Id,
                ReservaId = checkIn.ReservaId,
                DataHoraCheckIn = checkIn.DataHoraCheckIn,
                NumeroDeClientesPresentes = checkIn.NumeroDeClientesPresentes,
                Status = checkIn.Status
            };
        }

        public CheckIn ParaCheckIn()
        {
            if (ReservaId <= 0)
                throw new ArgumentException("ReservaId deve ser maior que zero.", nameof(ReservaId));

            return new CheckIn(
                ReservaId,
                DataHoraCheckIn,
                NumeroDeClientesPresentes
            )
            {
                Status = Status
            };
        }

        #endregion
    }
}
