using System;
using System.Collections.Generic;
using GestaoAlojamentosApp.Domain.Models;
using GestaoAlojamentosApp.Domain.Enums;

namespace GestaoAlojamentosApp.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Interface que define as assinaturas de m�todos de acesso a dados para pagamentos.
    /// Autor: Tiago Vale
    /// Email: a27675@alunos.ipca.pt
    /// Instituto: IPCA
    /// </summary>
    public interface IPagamentoRepository : IRepositoryBase<Pagamento>
    {

        /// <summary>
        /// Obt�m uma lista de pagamentos associados a uma reserva.
        /// </summary>
        /// <param name="reservaId">O ID da reserva associada aos pagamentos.</param>
        /// <returns>Uma lista de pagamentos associados � reserva.</returns>
        List<Pagamento> ObterPagamentosPorReserva(int reservaId);

        /// <summary>
        /// Obt�m uma lista de pagamentos associados a um cliente.
        /// </summary>
        /// <param name="clienteId">O ID do cliente associado aos pagamentos.</param>
        /// <returns>Uma lista de pagamentos associados ao cliente.</returns>
        List<Pagamento> ObterPagamentosPorCliente(int clienteId);

        /// <summary>
        /// Obt�m uma lista de pagamentos associados a um alojamento.
        /// </summary>
        /// <param name="alojamentoId">O ID do alojamento associado aos pagamentos.</param>
        /// <returns>Uma lista de pagamentos associados ao alojamento.</returns>
        List<Pagamento> ObterPagamentosPorAlojamento(int alojamentoId);

        /// <summary>
        /// Obt�m uma lista de pagamentos por m�todo de pagamento.
        /// </summary>
        /// <param name="metodoPagamento">O m�todo de pagamento utilizado para a pesquisa.</param>
        /// <returns>Uma lista de pagamentos associados ao m�todo de pagamento.</returns>
        List<Pagamento> ObterPagamentosPorMetodo(MetodoPagamento metodoPagamento);

        /// <summary>
        /// Obt�m uma lista de pagamentos por status.
        /// </summary>
        /// <param name="status">O status do pagamento utilizado para filtrar os pagamentos.</param>
        /// <returns>Uma lista de pagamentos com o status.</returns>
        List<Pagamento> ObterPagamentosPorStatus(StatusPagamento status);

    }
}
