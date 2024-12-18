/* 
   @file: Administrador.cs
   @autor: Tiago Vale
   @data: 5 de novembro de 2024
   @email: a27675@alunos.ipca.pt
   @descrição: Classe que representa um administrador, contém autenticação.
*/

using System;
using GestaoAlojamentosApp.Domain.Models.Enums;
using GestaoAlojamentosApp.Utils.Validacoes;
using GestaoAlojamentosApp.Utils.CriarIds;

namespace GestaoAlojamentosApp.Domain.Models.Entities
{
    public class Administrador : PessoaBase
    {
        private string SenhaHash { get; set; }
        private string Salt { get; set; }

        // Construtor do Administrador
        public Administrador(string nome, string email, string telefone, int idade, string senha)
            : base(nome, email, telefone, idade, TipoUtilizador.Administrador)
        {
            // Validação da senha
            Validador.ValidarSenha(senha);

            // Hash da senha e salt
            SenhaHash = Validador.HashSenha(senha, out string salt);
            Salt = salt;
        }

        // Método para verificar a senha
        public bool VerificarSenha(string senha)
        {
            string hashSenhaDigitada = Validador.HashSenha(senha, out string saltGerado);
            return hashSenhaDigitada == SenhaHash;
        }
    }
}
