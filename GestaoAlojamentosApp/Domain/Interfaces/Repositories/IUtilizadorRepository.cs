using System;
using System.Collections.Generic;
using GestaoAlojamentosApp.Domain.Models;

namespace GestaoAlojamentosApp.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Interface que define as assinaturas de métodos relativamente à gestão de utilizadores.
    /// Autor: Tiago Vale
    /// Email: a27675@alunos.ipca.pt
    /// Instituto: IPCA
    /// </summary>
    public interface IUtilizadorRepository : IRepositoryBase<Utilizador>
    {
        /// <summary>
        /// Obtém um utilizador pelo seu ID único.
        /// </summary>
        /// <param name="utilizadorId">O ID único do utilizador a ser recuperado.</param>
        /// <returns>O utilizador correspondente ao ID fornecido, ou null se não encontrado.</returns>
        Utilizador? ObterUtilizadorPorId(Guid utilizadorId);

        /// <summary>
        /// Obtém um utilizador pelo seu nome de usuário.
        /// </summary>
        /// <param name="username">O nome de usuário do utilizador a ser recuperado.</param>
        /// <returns>O utilizador correspondente ao nome de usuário fornecido, ou null se não encontrado.</returns>
        Utilizador? ObterUtilizadorPorUsername(string username);

        /// <summary>
        /// Lista todos os utilizadores no sistema.
        /// </summary>
        /// <returns>Uma lista de todos os utilizadores registados no sistema.</returns>
        List<Utilizador> ListarTodosUtilizadores();
    }
}
