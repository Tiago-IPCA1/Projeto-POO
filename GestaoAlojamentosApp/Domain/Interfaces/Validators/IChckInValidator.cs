using System;
using GestaoAlojamentosApp.Domain.Models;

namespace GestaoAlojamentosApp.Domain.Interfaces.Validators
{
    /// <summary>
    /// Interface que define as assinaturas de métodos relativos à validação de checkins.
    /// Esta interface contém métodos que garantem que as propriedades dos checkins sejam válidas de acordo com as regras de negócios.
    /// Autor: Tiago Vale
    /// Email: a27675@alunos.ipca.pt
    /// Instituto: IPCA
    /// </summary>
    public interface ICheckInValidator
    {
        /// <summary>
        /// Valida o número de clientes para um check-in.
        /// </summary>
        /// <param name="numeroDeClientes">Número de clientes que estão a fazer o check-in.</param>
        /// <returns>Retorna verdadeiro se o número de clientes for válido, caso contrário retorna falso.</returns>
        bool ValidarNumeroDeClientes(int numeroDeClientes);

        /// <summary>
        /// Valida a data e hora do check-in.
        /// </summary>
        /// <param name="dataHoraCheckIn">Data e hora do check-in.</param>
        /// <returns>Retorna verdadeiro se a data e hora do check-in forem válidas, caso contrário retorna falso.</returns>
        bool ValidarDataHoraCheckIn(DateTime dataHoraCheckIn);

        /// <summary>
        /// Valida o objeto CheckIn completo.
        /// </summary>
        /// <param name="checkIn">Objeto que representa o check-in a ser validado.</param>
        /// <returns>Retorna verdadeiro se o check-in for válido, caso contrário retorna falso.</returns>
        bool ValidarCheckIn(CheckIn checkIn);
    }
}
