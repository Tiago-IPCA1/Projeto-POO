using System;
using GestaoAlojamentosApp.Domain.Models;
using GestaoAlojamentosApp.Domain.Interfaces.Validators;
using GestaoAlojamentosApp.Domain.Interfaces.Repositories;

namespace GestaoAlojamentosApp.Domain.Validators
{
    /// <summary>
    /// Classe respons�vel pela valida��o dos dados de check-in.
    /// Autor: Tiago Vale
    /// Email: a27675@alunos.ipca.pt
    /// Instituto: IPCA
    /// </summary>
    public class CheckInValidator : ICheckInValidator
    {
        private readonly ICheckInRepository _checkInRepository;

        #region Construtor

        public CheckInValidator(ICheckInRepository checkInRepository)
        {
            _checkInRepository = checkInRepository ?? throw new ArgumentNullException(nameof(checkInRepository));
        }

        #endregion

        #region M�todos de Valida��o

        public bool ValidarNumeroDeClientes(int numeroDeClientes)
        {
            if (numeroDeClientes <= 0)
                throw new ArgumentException("O n�mero de clientes presentes deve ser maior que zero.");
            return true;
        }

        public bool ValidarDataHoraCheckIn(DateTime dataHoraCheckIn)
        {
            if (dataHoraCheckIn > DateTime.Now)
                throw new ArgumentException("A data e hora do check-in n�o pode ser no futuro.");
            return true;
        }

        public bool ValidarCheckIn(CheckIn checkIn)
        {
            if (checkIn == null)
                throw new ArgumentNullException(nameof(checkIn), "O check-in n�o pode ser nulo.");

            // Valida todas as propriedades do checkin
            ValidarNumeroDeClientes(checkIn.NumeroDeClientesPresentes);
            ValidarDataHoraCheckIn(checkIn.DataHoraCheckIn);
            return true;
        }

        #endregion
    }
}
