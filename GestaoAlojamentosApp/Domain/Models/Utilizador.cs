using System;
using GestaoAlojamentosApp.Domain.Enums;

namespace GestaoAlojamentosApp.Domain.Models
{

    /// <summary>
    /// Classe que representa um utilizador do sistema, incluindo informações sobre o nome de usuário, senha,
    /// tipo de utilizador, e o ID de pessoa associado. Esta classe é usada para gerir o acesso e controle
    /// do sistema, bem como o tipo de permissão do utilizador.
    /// Autor: Tiago Vale
    /// Email: a27675@alunos.ipca.pt
    /// Instituto: IPCA
    public class Utilizador
    {
        public Guid Id { get; private set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public TipoUtilizador Tipo { get; set; }
        public int PessoaId { get; set; }

        #region Construtores
        
        /// <summary>
        /// Construtor da classe Utilizador.
        /// Inicializa um novo utilizador com o nome de usuário, senha hash, tipo de utilizador e ID de pessoa.
        /// </summary>
        /// <param name="username">Nome de usuário do utilizador.</param>
        /// <param name="passwordHash">Senha criptografada (hash) do utilizador.</param>
        /// <param name="tipo">Tipo de utilizador (Admin, Cliente, etc.).</param>
        /// <param name="pessoaId">Identificador da pessoa associada ao utilizador.</param>
        public Utilizador(string username, string passwordHash, TipoUtilizador tipo, int pessoaId)
        {
            Id = Guid.NewGuid();
            Username = username;
            PasswordHash = passwordHash;
            Tipo = tipo;
            PessoaId = pessoaId;
        }

        #endregion
    }
}
