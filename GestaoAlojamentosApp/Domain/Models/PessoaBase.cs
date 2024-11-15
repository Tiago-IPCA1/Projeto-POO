/* Autor: Tiago Vale
   Data: 10 de novembro de 2024
   Email: a27675@alunos.ipca.pt
   Descrição: Classe para todas as pessoas (Administrador e Cliente)
*/
using System;
using GestaoAlojamentosApp.Domain.Enums;
using GestaoAlojamentosApp.Domain.Utils;
using GestaoAlojamentosApp.Domain.Validacoes;

namespace GestaoAlojamentosApp.Domain.Models
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
