using System;
using GestaoAlojamentosApp.Domain.Interfaces.Services;
using GestaoAlojamentosApp.Domain.Models;

namespace GestaoAlojamentosApp.App.Controllers
{
    /// <summary>
    /// Controlador responsável pela gestao de login
    /// Autor: Tiago Vale
    /// Email: a27675@alunos.ipca.pt
    /// Instituto: IPCA
    /// </summary>
    public class UtilizadorController
    {
        #region Atributos

        private readonly IUtilizadorService _utilizadorService;

        #endregion

        #region Construtor

        public UtilizadorController(IUtilizadorService utilizadorService)
        {
            _utilizadorService = utilizadorService;
        }

        #endregion

        #region Métodos de Login

        /// <summary>
        /// Método responsável por validar o login.
        /// </summary>
        public bool RealizarLogin(string username, string senha)
        {
            var utilizador = _utilizadorService.ObterUtilizadorPorUsername(username);

            if (utilizador != null && BCrypt.Net.BCrypt.Verify(senha, utilizador.PasswordHash))
            {
                return true; // Login bem-sucedido
            }
            return false; // Falha no login
        }

        #endregion
    }
}
