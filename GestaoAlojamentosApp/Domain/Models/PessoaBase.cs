using System;
using GestaoAlojamentosApp.Utils.CriarIds;

namespace GestaoAlojamentosApp.Domain.Models
{
    /// <summary>
    /// Classe base abstrata que define as propriedades comuns para uma pessoa.
    /// Autor: Tiago Vale
    /// Email: a27675@alunos.ipca.pt
    /// Instituto: IPCA
    /// </summary>
    public abstract class PessoaBase
    {
        public int Id { get; private set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public int Idade { get; set; }

        /// <summary>
        /// Construtor da classe PessoaBase.
        /// </summary>
        /// <param name="nome">Nome da pessoa.</param>
        /// <param name="email">Email da pessoa.</param>
        /// <param name="telefone">Telefone da pessoa.</param>
        /// <param name="idade">Idade da pessoa.</param>
        protected PessoaBase(string nome, string email, string telefone, int idade)
        {
            Id = GerarId(); // Chama o método que será sobrescrito nas classes derivadas
            Nome = nome;
            Email = email;
            Telefone = telefone;
            Idade = idade;
        }

        /// <summary>
        /// Método abstrato para gerar o ID de uma pessoa.
        /// Este método será implementado nas classes derivadas (ex: Cliente, Administrador).
        /// </summary>
        /// <returns>ID gerado para a pessoa.</returns>
        protected abstract int GerarId();
    }
}
