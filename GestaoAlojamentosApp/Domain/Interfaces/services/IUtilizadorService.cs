using System;
using System.Collections.Generic;
using GestaoAlojamentosApp.Domain.Models;

namespace GestaoAlojamentosApp.Domain.Interfaces.Services
{
    /// <summary>
    /// Interface que define as assinaturas de métodos relativos à gestão de utilizadores.
    /// Autor: Tiago Vale
    /// Email: a27675@alunos.ipca.pt
    /// Instituto: IPCA
    /// </summary>
    public interface IUtilizadorService
    {
        /// <summary>
        /// Cria um novo utilizador no sistema.
        /// </summary>
        /// <param name="utilizador">O objeto que contém as informações do utilizador a ser criado.</param>
        void CriarUtilizador(Utilizador utilizador);

        /// <summary>
        /// Cria o utilizador inicial no sistema (um administrador de configuração).
        /// </summary>
        void CriarUsuarioInicial();

        /// <summary>
        /// Atualiza os dados de um utilizador existente.
        /// </summary>
        /// <param name="utilizador">O objeto que contém as novas informações do utilizador a ser atualizado.</param>
        void AtualizarUtilizador(Utilizador utilizador);

        /// <summary>
        /// Exclui um utilizador do sistema.
        /// </summary>
        /// <param name="utilizadorId">O identificador único do utilizador a ser excluído.</param>
        void ExcluirUtilizador(Guid utilizadorId);

        /// <summary>
        /// Lista todos os utilizadores registados no sistema.
        /// </summary>
        /// <returns>Uma lista que contém todos os utilizadores registados.</returns>
        List<Utilizador> ListarTodosUtilizadores();

        /// <summary>
        /// Obtém um utilizador pelo seu ID único.
        /// </summary>
        /// <param name="utilizadorId">O identificador único do utilizador.</param>
        /// <returns>O utilizador correspondente ao ID ou null se não encontrado.</returns>
        Utilizador? ObterUtilizadorPorId(Guid utilizadorId);

        /// <summary>
        /// Obtém um utilizador pelo seu nome de usuário.
        /// </summary>
        /// <param name="username">O nome de usuário do utilizador.</param>
        /// <returns>O utilizador correspondente ao nome de usuário ou null se não encontrado.</returns>
        Utilizador? ObterUtilizadorPorUsername(string username);
    }
}
