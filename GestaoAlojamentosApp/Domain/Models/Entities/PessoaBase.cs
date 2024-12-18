/* @file: PessoaBase.cs
   @autor: Tiago Vale
   @data: 5 de novembro de 2024
   @email: a27675@alunos.ipca.pt
   @descrição: Classe para todas as pessoas (Administrador e Cliente).
*/

using System;
using GestaoAlojamentosApp.Domain.Models.Enums;
using GestaoAlojamentosApp.Utils.Validacoes;
using GestaoAlojamentosApp.Utils.CriarIds;

namespace GestaoAlojamentosApp.Domain.Models.Entities
{
    public abstract class PessoaBase
    {
        #region Propriedades

        // Propriedades
        public int Id { get; private set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public int Idade { get; set; }
        public TipoUtilizador TipoUtilizador { get; protected set; }

        #endregion

        #region Construtores

        // Construtor 
        protected PessoaBase(string nome, string email, string telefone, int idade, TipoUtilizador tipoUtilizador)
        {
            // Validações realizadas na classe Validador
            Validador.ValidarNome(nome);
            Validador.ValidarEmail(email);
            Validador.ValidarTelefone(telefone);
            Validador.ValidarIdade(idade);

            Id = CriarIds.CriarNovoId();
            Nome = nome;
            Email = email;
            Telefone = telefone;
            Idade = idade;
            TipoUtilizador = tipoUtilizador;
        }

        #endregion
    }
}
