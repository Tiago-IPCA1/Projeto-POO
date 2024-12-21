using System;
using System.Collections.Generic;
using GestaoAlojamentosApp.Domain.Models;

namespace GestaoAlojamentosApp.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Interface que define as assinaturas de métodos de acesso a dados para clientes.
    /// Autor: Tiago Vale
    /// Email: a27675@alunos.ipca.pt
    /// Instituto: IPCA
    /// </summary>
    public interface IClienteRepository : IRepositoryBase<Cliente>
    {

        /// <summary>
        /// Obtém uma lista de clientes pelo nome.
        /// </summary>
        /// <param name="nome">O nome do cliente a ser pesquisado.</param>
        /// <returns>Uma lista de clientes com o nome fornecido.</returns>
        List<Cliente> ObterClientesPorNome(string nome);

        /// <summary>
        /// Obtém uma lista de clientes pelo email.
        /// </summary>
        /// <param name="email">O email do cliente a ser pesquisado.</param>
        /// <returns>Uma lista de clientes com o email fornecido.</returns>
        List<Cliente> ObterClientesPorEmail(string email);

    }
}
