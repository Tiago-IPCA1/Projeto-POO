/* Autor: Tiago Vale
   Data: 10 de novembro de 2024
   Email: a27675@alunos.ipca.pt
   Descrição: Classe que representa um administrador, contém autenticação
*/

using System;
using GestaoAlojamentosApp.Domain.Validacoes;
using GestaoAlojamentosApp.Domain.Enums;

namespace GestaoAlojamentosApp.Domain.Models
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
            SenhaHash = Validacoes.HashSenha(senha, out string salt);
            Salt = salt;
        }
    }
}
