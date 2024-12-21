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

        #region Métodos CRUD

        public void CriarUtilizador(Utilizador utilizador)
        {
            // Verifica se já existe um utilizador com o mesmo nome de usuário
            if (_utilizadorRepository.ObterUtilizadorPorUsername(utilizador.Username) == null)
            {
                _utilizadorRepository.Adicionar(utilizador);  // Usa o método genérico da RepositoryBase
            }
            else
            {
                throw new InvalidOperationException("Já existe um utilizador com este nome de usuário.");
            }
        }

        public void AtualizarUtilizador(Utilizador utilizador)
        {
            var utilizadorExistente = _utilizadorRepository.ObterUtilizadorPorId(utilizador.Id);
            if (utilizadorExistente == null)
            {
                throw new KeyNotFoundException("Utilizador não encontrado.");
            }

            _utilizadorRepository.Atualizar(utilizador);  // Usa o método genérico da RepositoryBase
        }

        public void ExcluirUtilizador(Guid utilizadorId)
        {
            var utilizador = _utilizadorRepository.ObterUtilizadorPorId(utilizadorId);
            if (utilizador == null)
            {
                throw new KeyNotFoundException("Utilizador não encontrado.");
            }

            _utilizadorRepository.Remover(utilizadorId);  // Usa o método genérico da RepositoryBase, passando o Guid diretamente
        }

        #endregion

        #region Métodos de Consulta

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

        #region Métodos Auxiliares

        // Método que cria o usuário inicial "admin" (de administrador)
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
                CriarUtilizador(novoUtilizador); // Chama o método de criação
            }
        }

        #endregion
    }
}
