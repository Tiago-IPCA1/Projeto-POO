using System;
using System.Collections.Generic;
using GestaoAlojamentosApp.Domain.Models;
using GestaoAlojamentosApp.Domain.Enums;

namespace GestaoAlojamentosApp.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Interface que define as assinaturas de acesso a dados para reservas.
    /// Autor: Tiago Vale
    /// Email: a27675@alunos.ipca.pt
    /// Instituto: IPCA
    /// </summary>
    public interface IReservaRepository : IRepositoryBase<Reserva>
    {
        /// <summary>
        /// Obtém uma lista de reservas associadas a um cliente específico.
        /// </summary>
        /// <param name="clienteId">O ID do cliente cujas reservas serão recuperadas.</param>
        /// <returns>Uma lista de reservas associadas ao cliente especificado.</returns>
        List<Reserva> ObterReservasPorCliente(int clienteId);

        /// <summary>
        /// Obtém uma lista de reservas associadas a um alojamento específico.
        /// </summary>
        /// <param name="alojamentoId">O ID do alojamento cujas reservas serão recuperadas.</param>
        /// <returns>Uma lista de reservas associadas ao alojamento.</returns>
        List<Reserva> ObterReservasPorAlojamento(int alojamentoId);

        /// <summary>
        /// Obtém uma lista de reservas disponíveis dentro de um intervalo de datas.
        /// </summary>
        /// <param name="dataInicio">A data de início do intervalo para verificar disponibilidade.</param>
        /// <param name="dataFim">A data final do intervalo para verificar disponibilidade.</param>
        /// <returns>Uma lista de reservas disponíveis dentro do intervalo de datas devidas.</returns>
        List<Reserva> ObterReservasDisponiveis(DateTime dataInicio, DateTime dataFim);

        /// <summary>
        /// Obtém uma lista de reservas com base em seu status atual.
        /// </summary>
        /// <param name="status">O status das reservas que serão recuperadas.</param>
        /// <returns>Uma lista de reservas com o status.</returns>
        List<Reserva> ObterPorStatus(StatusReserva status);

        /// <summary>
        /// Atualiza o status de uma reserva específica.
        /// </summary>
        /// <param name="id">O ID da reserva cujo status será alterado.</param>
        /// <param name="status">O novo status a ser atribuído à reserva.</param>
        void AtualizarStatus(int id, StatusReserva status);
    }
}
