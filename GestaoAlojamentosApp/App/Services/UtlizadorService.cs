using GestaoAlojamentosApp.Domain.Interfaces.Repositories;
using GestaoAlojamentosApp.Domain.Interfaces.Services;
using GestaoAlojamentosApp.Domain.Enums;
using GestaoAlojamentosApp.Domain.Models;
using System;
using System.Collections.Generic;

namespace GestaoAlojamentosApp.App.Services
{
    public class UtilizadorService : IUtilizadorService
    {
        private readonly IUtilizadorRepository _utilizadorRepository;

        // Construtor
        public UtilizadorService(IUtilizadorRepository utilizadorRepository)
        {
            _utilizadorRepository = utilizadorRepository;
        }

        #region M�todos CRUD

        public void CriarUtilizador(Utilizador utilizador)
        {
            // Verifica se j� existe um utilizador com o mesmo nome de usu�rio
            if (_utilizadorRepository.ObterUtilizadorPorUsername(utilizador.Username) == null)
            {
                _utilizadorRepository.Adicionar(utilizador);  // Usa o m�todo gen�rico da RepositoryBase
            }
            else
            {
                throw new InvalidOperationException("J� existe um utilizador com este nome de usu�rio.");
            }
        }

        public void AtualizarUtilizador(Utilizador utilizador)
        {
            var utilizadorExistente = _utilizadorRepository.ObterUtilizadorPorId(utilizador.Id);
            if (utilizadorExistente == null)
            {
                throw new KeyNotFoundException("Utilizador n�o encontrado.");
            }

            _utilizadorRepository.Atualizar(utilizador);  // Usa o m�todo gen�rico da RepositoryBase
        }

        public void ExcluirUtilizador(Guid utilizadorId)
        {
            var utilizador = _utilizadorRepository.ObterUtilizadorPorId(utilizadorId);
            if (utilizador == null)
            {
                throw new KeyNotFoundException("Utilizador n�o encontrado.");
            }

            _utilizadorRepository.Remover(utilizadorId);  // Usa o m�todo gen�rico da RepositoryBase, passando o Guid diretamente
        }

        #endregion

        #region M�todos de Consulta

        public Utilizador? ObterUtilizadorPorId(Guid utilizadorId)
        {
            return _utilizadorRepository.ObterUtilizadorPorId(utilizadorId);
        }

        public Utilizador? ObterUtilizadorPorUsername(string username)
        {
            return _utilizadorRepository.ObterUtilizadorPorUsername(username);
        }

        public List<Utilizador> ListarTodosUtilizadores()
        {
            return _utilizadorRepository.ListarTodosUtilizadores();
        }

        #endregion

        #region M�todos Auxiliares

        // M�todo que cria o usu�rio inicial "admin" (de administrador)
        public void CriarUsuarioInicial()
        {
            if (ObterUtilizadorPorUsername("admin") == null)
            {
                string nomeUsuario = "admin"; // nome
                string senha = "admin123";  // senha
                var tipo = TipoUtilizador.Administrador;
                int pessoaId = 1;

                string passwordHash = BCrypt.Net.BCrypt.HashPassword(senha); // Criptografa a senha

                var novoUtilizador = new Utilizador(nomeUsuario, passwordHash, tipo, pessoaId);
                CriarUtilizador(novoUtilizador); // Chama o m�todo de cria��o
            }
        }

        #endregion
    }
}
