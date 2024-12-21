using System;
using System.Collections.Generic;
using GestaoAlojamentosApp.Domain.Models;
using GestaoAlojamentosApp.Domain.Enums;

namespace GestaoAlojamentosApp.Domain.Interfaces.Services
{
    /// <summary>
    /// Interface que define as assinaturas de métodos para a gestão de pagamentos.
    /// Autor: Tiago Vale
    /// Email: a27675@alunos.ipca.pt
    /// Instituto: IPCA
    /// </summary>
    public interface IPagamentoService
    {
        /// <summary>
        /// Cria um novo pagamento.
        /// </summary>
        /// <param name="reservaId">Identificador da reserva associada ao pagamento.</param>
        /// <param name="valor">Valor total do pagamento realizado.</param>
        /// <param name="metodoPagamento">Método de pagamento utilizado (por exemplo, cartão de crédito, transferência bancária).</param>
        /// <param name="status">Status atual do pagamento (por exemplo, pendente).</param>
        /// <param name="dataPagamento">Data e hora em que o pagamento foi realizado.</param>
        /// <returns>Retorna verdadeiro se o pagamento for criado com sucesso, falso caso contrário.</returns>
        bool CriarPagamento(int reservaId, decimal valor, MetodoPagamento metodoPagamento, StatusPagamento status, DateTime dataPagamento);

        /// <summary>
        /// Adiciona um pagamento existente.
        /// </summary>
        /// <param name="pagamento">Objeto de pagamento que será adicionado.</param>
        /// <returns>Retorna verdadeiro se o pagamento for adicionado com sucesso, falso caso contrário.</returns>
        bool AdicionarPagamento(Pagamento pagamento);

        /// <summary>
        /// Remove um pagamento pelo seu ID.
        /// </summary>
        /// <param name="id">Identificador único do pagamento a ser removido.</param>
        /// <returns>Retorna verdadeiro se o pagamento for removido com sucesso, falso caso contrário.</returns>
        bool RemoverPagamentoPorId(int id);

        /// <summary>
        /// Altera o status de um pagamento.
        /// </summary>
        /// <param name="id">Identificador único do pagamento cujo status será alterado.</param>
        /// <param name="status">Novo status do pagamento (por exemplo, pendente, cancelado).</param>
        /// <returns>Retorna verdadeiro se o status do pagamento for alterado com sucesso, falso caso contrário.</returns>
        bool AlterarStatusPagamento(int id, StatusPagamento status);

        /// <summary>
        /// Obtém um pagamento pelo seu ID.
        /// </summary>
        /// <param name="id">Identificador único do pagamento.</param>
        /// <returns>Retorna o pagamento correspondente ao ID ou null se não encontrado.</returns>
        Pagamento? ObterPagamentoPorId(int id);

        /// <summary>
        /// Obtém os pagamentos de uma reserva.
        /// </summary>
        /// <param name="reservaId">Identificador da reserva a ser consultada.</param>
        /// <returns>Lista de pagamentos associados à reserva.</returns>
        List<Pagamento> ObterPagamentosPorReserva(int reservaId);

        /// <summary>
        /// Obtém os pagamentos de um cliente.
        /// </summary>
        /// <param name="clienteId">Identificador único do cliente a ser consultado.</param>
        /// <returns>Lista de pagamentos associados ao cliente.</returns>
        List<Pagamento> ObterPagamentosPorCliente(int clienteId);

        /// <summary>
        /// Obtém os pagamentos de um alojamento.
        /// </summary>
        /// <param name="alojamentoId">Identificador único do alojamento a ser consultado.</param>
        /// <returns>Lista de pagamentos associados ao alojamento.</returns>
        List<Pagamento> ObterPagamentosPorAlojamento(int alojamentoId);

        /// <summary>
        /// Obtém os pagamentos por método de pagamento.
        /// </summary>
        /// <param name="metodoPagamento">Método de pagamento usado para filtrar os pagamentos.</param>
        /// <returns>Lista de pagamentos filtrados pelo método de pagamento.</returns>
        List<Pagamento> ObterPagamentosPorMetodo(MetodoPagamento metodoPagamento);

        /// <summary>
        /// Obtém os pagamentos por status.
        /// </summary>
        /// <param name="status">Status do pagamento para filtrar (por exemplo, pendente, cancelado).</param>
        /// <returns>Lista de pagamentos filtrados pelo status.</returns>
        List<Pagamento> ObterPagamentosPorStatus(StatusPagamento status);

        /// <summary>
        /// Obtém todos os pagamentos.
        /// </summary>
        /// <returns>Lista de todos os pagamentos realizados.</returns>
        List<Pagamento> ObterTodosPagamentos();
    }
}
