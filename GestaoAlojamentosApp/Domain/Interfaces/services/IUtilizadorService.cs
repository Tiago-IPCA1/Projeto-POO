using System;
using System.Collections.Generic;
using GestaoAlojamentosApp.Domain.Models;

namespace GestaoAlojamentosApp.Domain.Interfaces.Services
{
    /// <summary>
    /// Interface que define as assinaturas de m�todos relativos � gest�o de utilizadores.
    /// Autor: Tiago Vale
    /// Email: a27675@alunos.ipca.pt
    /// Instituto: IPCA
    /// </summary>
    public interface IUtilizadorService
    {
        /// <summary>
        /// Cria um novo utilizador no sistema.
        /// </summary>
        /// <param name="utilizador">O objeto que cont�m as informa��es do utilizador a ser criado.</param>
        void CriarUtilizador(Utilizador utilizador);

        /// <summary>
        /// Cria o utilizador inicial no sistema (um administrador de configura��o).
        /// </summary>
        void CriarUsuarioInicial();

        /// <summary>
        /// Atualiza os dados de um utilizador existente.
        /// </summary>
        /// <param name="utilizador">O objeto que cont�m as novas informa��es do utilizador a ser atualizado.</param>
        void AtualizarUtilizador(Utilizador utilizador);

        /// <summary>
        /// Exclui um utilizador do sistema.
        /// </summary>
        /// <param name="utilizadorId">O identificador �nico do utilizador a ser exclu�do.</param>
        void ExcluirUtilizador(Guid utilizadorId);

        /// <summary>
        /// Lista todos os utilizadores registados no sistema.
        /// </summary>
        /// <returns>Uma lista que cont�m todos os utilizadores registados.</returns>
        List<Utilizador> ListarTodosUtilizadores();

        /// <summary>
        /// Obt�m um utilizador pelo seu ID �nico.
        /// </summary>
        /// <param name="utilizadorId">O identificador �nico do utilizador.</param>
        /// <returns>O utilizador correspondente ao ID ou null se n�o encontrado.</returns>
        Utilizador? ObterUtilizadorPorId(Guid utilizadorId);

        /// <summary>
        /// Obt�m um utilizador pelo seu nome de usu�rio.
        /// </summary>
        /// <param name="username">O nome de usu�rio do utilizador.</param>
        /// <returns>O utilizador correspondente ao nome de usu�rio ou null se n�o encontrado.</returns>
        Utilizador? ObterUtilizadorPorUsername(string username);
    }
}
