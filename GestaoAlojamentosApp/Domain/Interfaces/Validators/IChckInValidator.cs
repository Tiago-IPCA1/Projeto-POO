using System;
using GestaoAlojamentosApp.Domain.Models;

namespace GestaoAlojamentosApp.Domain.Interfaces.Validators
{
    /// <summary>
    /// Interface que define as assinaturas de m�todos relativos � valida��o de checkins.
    /// Esta interface cont�m m�todos que garantem que as propriedades dos checkins sejam v�lidas de acordo com as regras de neg�cios.
    /// Autor: Tiago Vale
    /// Email: a27675@alunos.ipca.pt
    /// Instituto: IPCA
    /// </summary>
    public interface ICheckInValidator
    {
        /// <summary>
        /// Valida o n�mero de clientes para um check-in.
        /// </summary>
        /// <param name="numeroDeClientes">N�mero de clientes que est�o a fazer o check-in.</param>
        /// <returns>Retorna verdadeiro se o n�mero de clientes for v�lido, caso contr�rio retorna falso.</returns>
        bool ValidarNumeroDeClientes(int numeroDeClientes);

        /// <summary>
        /// Valida a data e hora do check-in.
        /// </summary>
        /// <param name="dataHoraCheckIn">Data e hora do check-in.</param>
        /// <returns>Retorna verdadeiro se a data e hora do check-in forem v�lidas, caso contr�rio retorna falso.</returns>
        bool ValidarDataHoraCheckIn(DateTime dataHoraCheckIn);

        /// <summary>
        /// Valida o objeto CheckIn completo.
        /// </summary>
        /// <param name="checkIn">Objeto que representa o check-in a ser validado.</param>
        /// <returns>Retorna verdadeiro se o check-in for v�lido, caso contr�rio retorna falso.</returns>
        bool ValidarCheckIn(CheckIn checkIn);
    }
}
