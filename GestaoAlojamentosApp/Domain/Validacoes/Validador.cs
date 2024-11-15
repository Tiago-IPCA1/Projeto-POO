/* Autor: Tiago Vale
   Data: 10 de novembro de 2024
   Email: a27675@alunos.ipca.pt
   Descrição: Classe com métodos para validação de dados de entrada .
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
                throw new ArgumentException("O campo não pode ser vazio.");
            }

            if (nome.Length > 15)
            {
                throw new ArgumentException("O 'Nome' deve ter no máximo 15 caracteres.");
            }
        }

        // Valida o email 
        public static void ValidarEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("O campo não pode ser vazio.");
            }

            var regex = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
            if (!regex.IsMatch(email))
            {
                throw new ArgumentException("O email fornecido não tem um formato válido. Exemplo: utilizador@gmail.com.");
            }
        }

        // Valida o número de telefone
        public static void ValidarTelefone(string telefone)
        {
            if (string.IsNullOrWhiteSpace(telefone))
            {
                throw new ArgumentException("O campo não pode ser vazio.");
            }

            if (telefone.Length < 9 || !long.TryParse(telefone, out _))
            {
                throw new ArgumentException("O número deve conter pelo menos 9 dígitos numéricos.");
            }
        }

        // Valida a idade
        public static void ValidarIdade(int idade)
        {
            if (idade < 18)
            {
                throw new ArgumentException("A idade mínima permitida é de 18 anos.");
            }
        }

        // Valida a senha
        public static void ValidarSenha(string senha)
        {
            if (string.IsNullOrWhiteSpace(senha))
            {
                throw new ArgumentException("A senha não pode estar em branco. Por favor, forneça uma senha válida.");
            }

            if (senha.Length < 8)
            {
                throw new ArgumentException("A senha precisa ter pelo menos 8 caracteres para garantir sua segurança.");
            }

            if (!Regex.IsMatch(senha, @"[A-Z]"))
            {
                throw new ArgumentException("A senha deve conter pelo menos uma letra maiúscula.");
            }

            if (!Regex.IsMatch(senha, @"[a-z]"))
            {
                throw new ArgumentException("A senha deve conter pelo menos uma letra minúscula.");
            }

            if (!Regex.IsMatch(senha, @"\d"))
            {
                throw new ArgumentException("A senha deve incluir pelo menos um número.");
            }
        }
    }
}
