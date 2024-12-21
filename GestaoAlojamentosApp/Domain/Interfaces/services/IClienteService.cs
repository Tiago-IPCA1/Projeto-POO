using System;
using System.Collections.Generic;
using GestaoAlojamentosApp.Domain.Models;

namespace GestaoAlojamentosApp.Domain.Interfaces.Services
{
    /// <summary>
    /// Interface que define as assinaturas de métodos para a gestão de clientes.
    /// Autor: Tiago Vale
    /// Email: a27675@alunos.ipca.pt
    /// Instituto: IPCA
    /// </summary>
    public interface IClienteService
    {
        /// <summary>
        /// Cria um novo cliente.
        /// </summary>
        /// <param name="nome">Nome completo do cliente.</param>
        /// <param name="email">Endereço de e-mail do cliente.</param>
        /// <param name="telefone">Número de telefone do cliente.</param>
        /// <param name="idade">Idade do cliente.</param>
        /// <returns>Retorna verdadeiro se o cliente for criado com sucesso, falso caso contrário.</returns>
        bool CriarCliente(string nome, string email, string telefone, int idade);

        /// <summary>
        /// Atualiza um cliente existente.
        /// </summary>
        /// <param name="id">Identificador único do cliente a ser atualizado.</param>
        /// <param name="nome">Novo nome do cliente.</param>
        /// <param name="email">Novo e-mail do cliente.</param>
        /// <param name="telefone">Novo número de telefone do cliente.</param>
        /// <param name="idade">Nova idade do cliente.</param>
        /// <returns>Retorna verdadeiro se o cliente for atualizado com sucesso, falso caso contrário.</returns>
        bool AtualizarCliente(int id, string nome, string email, string telefone, int idade);

        /// <summary>
        /// Remove um cliente.
        /// </summary>
        /// <param name="id">Identificador único do cliente a ser removido.</param>
        /// <returns>Retorna verdadeiro se o cliente for removido com sucesso, falso caso contrário.</returns>
        bool RemoverCliente(int id);

        /// <summary>
        /// Obtém um cliente pelo seu ID.
        /// </summary>
        /// <param name="id">Identificador único do cliente.</param>
        /// <returns>Retorna o cliente correspondente ao ID, ou null se não encontrado.</returns>
        Cliente? ObterClientePorId(int id);

        /// <summary>
        /// Obtém todos os clientes registados.
        /// </summary>
        /// <returns>Lista de todos os clientes registados no sistema.</returns>
        List<Cliente> ObterTodosClientes();

        /// <summary>
        /// Obtém os clientes pelo nome.
        /// </summary>
        /// <param name="nome">Nome do cliente a ser pesquisado.</param>
        /// <returns>Lista de clientes que correspondem ao nome fornecido.</returns>
        List<Cliente> ObterClientesPorNome(string nome);

        /// <summary>
        /// Obtém os clientes pelo e-mail.
        /// </summary>
        /// <param name="email">Endereço de e-mail do cliente a ser pesquisado.</param>
        /// <returns>Lista de clientes que correspondem ao e-mail fornecido.</returns>
        List<Cliente> ObterClientesPorEmail(string email);
    }
}
