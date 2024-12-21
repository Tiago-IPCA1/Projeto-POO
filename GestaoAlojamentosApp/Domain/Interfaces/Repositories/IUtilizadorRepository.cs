using System;
using System.Collections.Generic;
using GestaoAlojamentosApp.Domain.Models;

namespace GestaoAlojamentosApp.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Interface que define as assinaturas de m�todos relativamente � gest�o de utilizadores.
    /// Autor: Tiago Vale
    /// Email: a27675@alunos.ipca.pt
    /// Instituto: IPCA
    /// </summary>
    public interface IUtilizadorRepository : IRepositoryBase<Utilizador>
    {
        /// <summary>
        /// Obt�m um utilizador pelo seu ID �nico.
        /// </summary>
        /// <param name="utilizadorId">O ID �nico do utilizador a ser recuperado.</param>
        /// <returns>O utilizador correspondente ao ID fornecido, ou null se n�o encontrado.</returns>
        Utilizador? ObterUtilizadorPorId(Guid utilizadorId);

        /// <summary>
        /// Obt�m um utilizador pelo seu nome de usu�rio.
        /// </summary>
        /// <param name="username">O nome de usu�rio do utilizador a ser recuperado.</param>
        /// <returns>O utilizador correspondente ao nome de usu�rio fornecido, ou null se n�o encontrado.</returns>
        Utilizador? ObterUtilizadorPorUsername(string username);

        /// <summary>
        /// Lista todos os utilizadores no sistema.
        /// </summary>
        /// <returns>Uma lista de todos os utilizadores registados no sistema.</returns>
        List<Utilizador> ListarTodosUtilizadores();
    }
}
