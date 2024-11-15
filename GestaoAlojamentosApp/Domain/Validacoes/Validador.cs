/* Autor: Tiago Vale
   Data: 10 de novembro de 2024
   Email: a27675@alunos.ipca.pt
   Descri��o: Classe com m�todos para valida��o de dados de entrada .
*/

using System;
using System.Text.RegularExpressions;

namespace GestaoAlojamentosApp.Domain.Validacoes
{
    public static class Validador
    {
        // Valida o nome 
        public static void ValidarNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                throw new ArgumentException("O campo n�o pode ser vazio.");
            }

            if (nome.Length > 15)
            {
                throw new ArgumentException("O 'Nome' deve ter no m�ximo 15 caracteres.");
            }
        }

        // Valida o email 
        public static void ValidarEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("O campo n�o pode ser vazio.");
            }

            var regex = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
            if (!regex.IsMatch(email))
            {
                throw new ArgumentException("O email fornecido n�o tem um formato v�lido. Exemplo: utilizador@gmail.com.");
            }
        }

        // Valida o n�mero de telefone
        public static void ValidarTelefone(string telefone)
        {
            if (string.IsNullOrWhiteSpace(telefone))
            {
                throw new ArgumentException("O campo n�o pode ser vazio.");
            }

            if (telefone.Length < 9 || !long.TryParse(telefone, out _))
            {
                throw new ArgumentException("O n�mero deve conter pelo menos 9 d�gitos num�ricos.");
            }
        }

        // Valida a idade
        public static void ValidarIdade(int idade)
        {
            if (idade < 18)
            {
                throw new ArgumentException("A idade m�nima permitida � de 18 anos.");
            }
        }

        // Valida a senha
        public static void ValidarSenha(string senha)
        {
            if (string.IsNullOrWhiteSpace(senha))
            {
                throw new ArgumentException("A senha n�o pode estar em branco. Por favor, forne�a uma senha v�lida.");
            }

            if (senha.Length < 8)
            {
                throw new ArgumentException("A senha precisa ter pelo menos 8 caracteres para garantir sua seguran�a.");
            }

            if (!Regex.IsMatch(senha, @"[A-Z]"))
            {
                throw new ArgumentException("A senha deve conter pelo menos uma letra mai�scula.");
            }

            if (!Regex.IsMatch(senha, @"[a-z]"))
            {
                throw new ArgumentException("A senha deve conter pelo menos uma letra min�scula.");
            }

            if (!Regex.IsMatch(senha, @"\d"))
            {
                throw new ArgumentException("A senha deve incluir pelo menos um n�mero.");
            }
        }
    }
}
