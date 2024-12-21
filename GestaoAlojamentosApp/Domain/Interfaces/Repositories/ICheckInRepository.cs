using System;
using System.Collections.Generic;
using GestaoAlojamentosApp.Domain.Models;
using GestaoAlojamentosApp.Domain.Enums;

namespace GestaoAlojamentosApp.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Interface que define as assinaturas de m�todos de acesso a dados para check-ins.
    /// Autor: Tiago Vale
    /// Email: a27675@alunos.ipca.pt
    /// Instituto: IPCA
    /// </summary>
    public interface ICheckInRepository : IRepositoryBase<CheckIn>
    {

        /// <summary>
        /// Verifica se j� existe um check-in para uma reserva.
        /// </summary>
        /// <param name="reservaId">O identificador �nico da reserva a ser verificado.</param>
        /// <returns>True se j� existe um check-in para a reserva, caso contr�rio, false.</returns>
        bool CheckInJaExiste(int reservaId);

        /// <summary>
        /// Obt�m uma lista de check-ins associados a uma reserva espec�fica.
        /// </summary>
        /// <param name="reservaId">O identificador �nico da reserva para a qual os check-ins s�o obtidos.</param>
        /// <returns>Uma lista de check-ins associados � reserva com o ID fornecido.</returns>
        List<CheckIn> ObterCheckInsPorReserva(int reservaId);

        /// <summary>
        /// Obt�m uma lista de check-ins por status.
        /// </summary>
        /// <param name="status">O status dos check-ins que devem ser retornados.</param>
        /// <returns>Uma lista de check-ins com o status.</returns>
        List<CheckIn> ObterCheckInsPorStatus(StatusCheckIn status);

    }
}
