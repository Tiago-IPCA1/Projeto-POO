using System;
using System.Collections.Generic;
using GestaoAlojamentosApp.Domain.Models;
using GestaoAlojamentosApp.Domain.Enums;

namespace GestaoAlojamentosApp.Domain.Interfaces.Services
{
    /// <summary>
    /// Interface que define as assinaturas de m�todos para a gest�o de pagamentos.
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
        /// <param name="metodoPagamento">M�todo de pagamento utilizado (por exemplo, cart�o de cr�dito, transfer�ncia banc�ria).</param>
        /// <param name="status">Status atual do pagamento (por exemplo, pendente).</param>
        /// <param name="dataPagamento">Data e hora em que o pagamento foi realizado.</param>
        /// <returns>Retorna verdadeiro se o pagamento for criado com sucesso, falso caso contr�rio.</returns>
        bool CriarPagamento(int reservaId, decimal valor, MetodoPagamento metodoPagamento, StatusPagamento status, DateTime dataPagamento);

        /// <summary>
        /// Adiciona um pagamento existente.
        /// </summary>
        /// <param name="pagamento">Objeto de pagamento que ser� adicionado.</param>
        /// <returns>Retorna verdadeiro se o pagamento for adicionado com sucesso, falso caso contr�rio.</returns>
        bool AdicionarPagamento(Pagamento pagamento);

        /// <summary>
        /// Remove um pagamento pelo seu ID.
        /// </summary>
        /// <param name="id">Identificador �nico do pagamento a ser removido.</param>
        /// <returns>Retorna verdadeiro se o pagamento for removido com sucesso, falso caso contr�rio.</returns>
        bool RemoverPagamentoPorId(int id);

        /// <summary>
        /// Altera o status de um pagamento.
        /// </summary>
        /// <param name="id">Identificador �nico do pagamento cujo status ser� alterado.</param>
        /// <param name="status">Novo status do pagamento (por exemplo, pendente, cancelado).</param>
        /// <returns>Retorna verdadeiro se o status do pagamento for alterado com sucesso, falso caso contr�rio.</returns>
        bool AlterarStatusPagamento(int id, StatusPagamento status);

        /// <summary>
        /// Obt�m um pagamento pelo seu ID.
        /// </summary>
        /// <param name="id">Identificador �nico do pagamento.</param>
        /// <returns>Retorna o pagamento correspondente ao ID ou null se n�o encontrado.</returns>
        Pagamento? ObterPagamentoPorId(int id);

        /// <summary>
        /// Obt�m os pagamentos de uma reserva.
        /// </summary>
        /// <param name="reservaId">Identificador da reserva a ser consultada.</param>
        /// <returns>Lista de pagamentos associados � reserva.</returns>
        List<Pagamento> ObterPagamentosPorReserva(int reservaId);

        /// <summary>
        /// Obt�m os pagamentos de um cliente.
        /// </summary>
        /// <param name="clienteId">Identificador �nico do cliente a ser consultado.</param>
        /// <returns>Lista de pagamentos associados ao cliente.</returns>
        List<Pagamento> ObterPagamentosPorCliente(int clienteId);

        /// <summary>
        /// Obt�m os pagamentos de um alojamento.
        /// </summary>
        /// <param name="alojamentoId">Identificador �nico do alojamento a ser consultado.</param>
        /// <returns>Lista de pagamentos associados ao alojamento.</returns>
        List<Pagamento> ObterPagamentosPorAlojamento(int alojamentoId);

        /// <summary>
        /// Obt�m os pagamentos por m�todo de pagamento.
        /// </summary>
        /// <param name="metodoPagamento">M�todo de pagamento usado para filtrar os pagamentos.</param>
        /// <returns>Lista de pagamentos filtrados pelo m�todo de pagamento.</returns>
        List<Pagamento> ObterPagamentosPorMetodo(MetodoPagamento metodoPagamento);

        /// <summary>
        /// Obt�m os pagamentos por status.
        /// </summary>
        /// <param name="status">Status do pagamento para filtrar (por exemplo, pendente, cancelado).</param>
        /// <returns>Lista de pagamentos filtrados pelo status.</returns>
        List<Pagamento> ObterPagamentosPorStatus(StatusPagamento status);

        /// <summary>
        /// Obt�m todos os pagamentos.
        /// </summary>
        /// <returns>Lista de todos os pagamentos realizados.</returns>
        List<Pagamento> ObterTodosPagamentos();
    }
}
