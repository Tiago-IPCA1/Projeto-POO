using System;
using System.Collections.Generic;
using GestaoAlojamentosApp.Domain.Models;
using GestaoAlojamentosApp.Domain.Enums;

namespace GestaoAlojamentosApp.Domain.Interfaces.Services
{
    /// <summary>
    /// Interface que define as assinaturas de métodos relativamente à gestão de reservas.
    /// Autor: Tiago Vale
    /// Email: a27675@alunos.ipca.pt
    /// Instituto: IPCA
    /// </summary>
    public interface IReservaService
    {
        /// <summary>
        /// Cria uma nova reserva.
        /// </summary>
        /// <param name="clienteId">Identificador único do cliente que está fazendo a reserva.</param>
        /// <param name="alojamentoId">Identificador único do alojamento que está sendo reservado.</param>
        /// <param name="dataInicio">Data de início da reserva.</param>
        /// <param name="dataFim">Data de término da reserva.</param>
        /// <param name="precoTotal">Preço total da reserva, que pode ser calculado com base no período e outros fatores.</param>
        /// <param name="numeroDePessoas">Número de pessoas para a reserva.</param>
        /// <returns>Retorna verdadeiro se a reserva for criada com sucesso, falso caso contrário.</returns>
        bool CriarReserva(int clienteId, int alojamentoId, DateTime dataInicio, DateTime dataFim, decimal precoTotal, int numeroDePessoas);

        /// <summary>
        /// Atualiza uma reserva existente.
        /// </summary>
        /// <param name="id">Identificador único da reserva a ser atualizada.</param>
        /// <param name="clienteId">Identificador único do cliente associado à reserva.</param>
        /// <param name="alojamentoId">Identificador único do alojamento associado à reserva.</param>
        /// <param name="dataInicio">Nova data de início da reserva.</param>
        /// <param name="dataFim">Nova data de término da reserva.</param>
        /// <param name="precoTotal">Novo preço total da reserva.</param>
        /// <param name="numeroDePessoas">Novo número de pessoas para a reserva.</param>
        /// <returns>Retorna verdadeiro se a reserva for atualizada com sucesso, falso caso contrário.</returns>
        bool AtualizarReserva(int id, int clienteId, int alojamentoId, DateTime dataInicio, DateTime dataFim, decimal precoTotal, int numeroDePessoas);

        /// <summary>
        /// Remove uma reserva.
        /// </summary>
        /// <param name="id">Identificador único da reserva a ser removida.</param>
        /// <returns>Retorna verdadeiro se a reserva for removida com sucesso, falso caso contrário.</returns>
        bool RemoverReserva(int id);

        /// <summary>
        /// Altera o status de uma reserva.
        /// </summary>
        /// <param name="id">Identificador único da reserva cujo status será alterado.</param>
        /// <param name="status">Novo status da reserva (por exemplo, pendente).</param>
        /// <returns>Retorna verdadeiro se o status da reserva for alterado com sucesso, falso caso contrário.</returns>
        bool AlterarStatusReserva(int id, StatusReserva status);

        /// <summary>
        /// Obtém todas as reservas registadas.
        /// </summary>
        /// <returns>Lista de todas as reservas registadas.</returns>
        List<Reserva> ObterTodasReservas();

        /// <summary>
        /// Obtém uma reserva pelo seu ID.
        /// </summary>
        /// <param name="id">Identificador único da reserva a ser recuperada.</param>
        /// <returns>Retorna a reserva correspondente ao ID ou null caso não seja encontrada.</returns>
        Reserva? ObterReservaPorId(int id);

        /// <summary>
        /// Obtém reservas associadas a um cliente específico.
        /// </summary>
        /// <param name="clienteId">Identificador único do cliente para filtrar as reservas.</param>
        /// <returns>Lista de reservas associadas ao cliente.</returns>
        List<Reserva> ObterReservasPorCliente(int clienteId);

        /// <summary>
        /// Obtém reservas associadas a um alojamento específico.
        /// </summary>
        /// <param name="alojamentoId">Identificador único do alojamento para filtrar as reservas.</param>
        /// <returns>Lista de reservas associadas ao alojamento.</returns>
        List<Reserva> ObterReservasPorAlojamento(int alojamentoId);

        /// <summary>
        /// Obtém reservas disponíveis em um período de datas.
        /// </summary>
        /// <param name="dataInicio">Data de início do período de pesquisa.</param>
        /// <param name="dataFim">Data de término do período de pesquisa.</param>
        /// <returns>Lista de reservas disponíveis durante o período especificado.</returns>
        List<Reserva> ObterReservasDisponiveis(DateTime dataInicio, DateTime dataFim);

        /// <summary>
        /// Obtém reservas por status.
        /// </summary>
        /// <param name="status">Status da reserva para filtrar as reservas (por exemplo, confirmada, pendente, cancelada).</param>
        /// <returns>Lista de reservas filtradas pelo status.</returns>
        List<Reserva> ObterReservasPorStatus(StatusReserva status);
    }
}
