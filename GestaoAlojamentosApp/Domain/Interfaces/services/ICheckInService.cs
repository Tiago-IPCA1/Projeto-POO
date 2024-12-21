using System;
using System.Collections.Generic;
using GestaoAlojamentosApp.Domain.Models;
using GestaoAlojamentosApp.Domain.Enums;

namespace GestaoAlojamentosApp.Domain.Interfaces.Services
{
    /// <summary>
    /// Interface que define as assinaturas de m�todos relativamente � gest�o de check-ins.
    /// Autor: Tiago Vale
    /// Email: a27675@alunos.ipca.pt
    /// Instituto: IPCA
    /// </summary>
    public interface ICheckInService
    {
        /// <summary>
        /// Cria um novo check-in.
        /// </summary>
        /// <param name="reservaId">Identificador da reserva associada ao check-in.</param>
        /// <param name="dataHoraCheckIn">Data e hora do check-in.</param>
        /// <param name="numeroDeClientesPresentes">N�mero de clientes presentes no check-in.</param>
        /// <returns>Retorna verdadeiro se o check-in for criado com sucesso, falso caso contr�rio.</returns>
        bool CriarCheckIn(int reservaId, DateTime dataHoraCheckIn, int numeroDeClientesPresentes);

        /// <summary>
        /// Altera o status de um check-in.
        /// </summary>
        /// <param name="id">Identificador do check-in a ser alterado.</param>
        /// <param name="status">Novo status do check-in (ex:Pendente, Cancelado).</param>
        /// <returns>Retorna verdadeiro se o status for alterado com sucesso, falso caso contr�rio.</returns>
        bool AlterarStatusCheckIn(int id, StatusCheckIn status);

        /// <summary>
        /// Remove um check-in.
        /// </summary>
        /// <param name="id">Identificador do check-in a ser removido.</param>
        /// <returns>Retorna verdadeiro se o check-in for removido com sucesso, falso caso contr�rio.</returns>
        bool RemoverCheckIn(int id);

        /// <summary>
        /// Obt�m um check-in pelo seu ID.
        /// </summary>
        /// <param name="id">Identificador �nico do check-in.</param>
        /// <returns>Retorna o check-in correspondente ao ID, ou null se n�o encontrado.</returns>
        CheckIn? ObterCheckInPorId(int id);

        /// <summary>
        /// Obt�m os check-ins de uma reserva espec�fica.
        /// </summary>
        /// <param name="reservaId">Identificador da reserva associada aos check-ins.</param>
        /// <returns>Lista de check-ins associados � reserva.</returns>
        List<CheckIn> ObterCheckInsPorReserva(int reservaId);

        /// <summary>
        /// Obt�m os check-ins por status.
        /// </summary>
        /// <param name="status">Status do check-in (ex: Pendente, Cancelado).</param>
        /// <returns>Lista de check-ins que correspondem ao status devido.</returns>
        List<CheckIn> ObterCheckInsPorStatus(StatusCheckIn status);

        /// <summary>
        /// Obt�m todos os check-ins.
        /// </summary>
        /// <returns>Lista de todos os check-ins.</returns>
        List<CheckIn> ObterTodosCheckIns();
    }
}
