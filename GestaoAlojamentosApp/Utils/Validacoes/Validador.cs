/* 
   @file: Validador.cs
   @autor: Tiago Vale
   @data: 10 de novembro de 2024
   @email: a27675@alunos.ipca.pt
   @descrição: Classe com métodos para validação de dados de entrada e geração de hash para senhas.
*/

using System;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Text;

namespace GestaoAlojamentosApp.Utils.Validacoes
{
    public static class Validador
    {
        // Valida o nome 
        public static void ValidarNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                throw new ArgumentException("Erro.");
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
                throw new ArgumentException("O campo nao pode ser vazio.");
            }

            var regex = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
            if (!regex.IsMatch(email))
            {
                throw new ArgumentException("O email fornecido nao tem um formato adequado. Exemplo: utilizador@gmail.com.");
            }
        }

        // Valida o número de telefone
        public static void ValidarTelefone(string telefone)
        {
            if (string.IsNullOrWhiteSpace(telefone))
            {
                throw new ArgumentException("Erro.");
            }

            if (telefone.Length < 9 || !long.TryParse(telefone, out _))
            {
                throw new ArgumentException("O numero deve conter pelo menos 9 digitos numericos.");
            }
        }

        // Valida a idade
        public static void ValidarIdade(int idade)
        {
            if (idade < 18)
            {
                throw new ArgumentException("A idade minima permitida e de 18 anos.");
            }
        }

        // Valida a senha
        public static void ValidarSenha(string senha)
        {
            if (string.IsNullOrWhiteSpace(senha))
            {
                throw new ArgumentException("Erro senha, nao pode estar vazio");
            }

            if (senha.Length < 8)
            {
                throw new ArgumentException("Pelos menos 8 caracteres para ser valido.");
            }

            if (!Regex.IsMatch(senha, @"[A-Z]"))
            {
                throw new ArgumentException("Pelo menos uma letra maiucula.");
            }

            if (!Regex.IsMatch(senha, @"[a-z]"))
            {
                throw new ArgumentException("Pelo menos uma letra minuscula");
            }

            if (!Regex.IsMatch(senha, @"\d"))
            {
                throw new ArgumentException("Pelo menos um numero");
            }
        }

        // Criar o hash da senha com salt
        public static string HashSenha(string senha, out string salt)
        {
            using (var rng = RandomNumberGenerator.Create()) 
            {
                byte[] saltBytes = new byte[16]; // Salt aleatório de 16 bytes
                rng.GetBytes(saltBytes); // Salt com valores aleatórios
                salt = Convert.ToBase64String(saltBytes); 

                using (var sha256 = SHA256.Create())
                {
                    byte[] senhaBytes = Encoding.UTF8.GetBytes(senha + salt);
                    byte[] hashBytes = sha256.ComputeHash(senhaBytes); // Cria o hash SHA256
                    return Convert.ToBase64String(hashBytes); // Retorna o hash em Base64
                }
            }
        }
    }
}
