using System;
using System.Collections.Generic;
using GestaoAlojamentosApp.Domain.Models;
using GestaoAlojamentosApp.Domain.Enums;

namespace GestaoAlojamentosApp.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Interface que define as assinaturas de métodos de acesso a dados para check-ins.
    /// Autor: Tiago Vale
    /// Email: a27675@alunos.ipca.pt
    /// Instituto: IPCA
    /// </summary>
    public interface ICheckInRepository : IRepositoryBase<CheckIn>
    {

        /// <summary>
        /// Verifica se já existe um check-in para uma reserva.
        /// </summary>
        /// <param name="reservaId">O identificador único da reserva a ser verificado.</param>
        /// <returns>True se já existe um check-in para a reserva, caso contrário, false.</returns>
        bool CheckInJaExiste(int reservaId);

        /// <summary>
        /// Obtém uma lista de check-ins associados a uma reserva específica.
        /// </summary>
        /// <param name="reservaId">O identificador único da reserva para a qual os check-ins são obtidos.</param>
        /// <returns>Uma lista de check-ins associados à reserva com o ID fornecido.</returns>
        List<CheckIn> ObterCheckInsPorReserva(int reservaId);

        /// <summary>
        /// Obtém uma lista de check-ins por status.
        /// </summary>
        /// <param name="status">O status dos check-ins que devem ser retornados.</param>
        /// <returns>Uma lista de check-ins com o status.</returns>
        List<CheckIn> ObterCheckInsPorStatus(StatusCheckIn status);

    }
}
