using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using GestaoAlojamentosApp.Domain.Enums;
using GestaoAlojamentosApp.Utils.CriarIds;


namespace GestaoAlojamentosApp.Domain.Models
{
    /// <summary>
    /// Classe que representa um cliente, estendendo a classe base PessoaBase,
    /// e incluindo uma lista de reservas feitas pelo cliente.
    /// Autor: Tiago Vale
    /// Email: a27675@alunos.ipca.pt
    /// Instituto: IPCA
    /// </summary>
    public class Cliente : PessoaBase
    {
        public List<Reserva> Reservas { get; private set; }

        /// <summary>
        /// Construtor da classe Cliente.
        /// </summary>
        /// <param name="nome">Nome do cliente.</param>
        /// <param name="email">Email do cliente.</param>
        /// <param name="telefone">Telefone do cliente.</param>
        /// <param name="idade">Idade do cliente.</param>
        public Cliente(string nome, string email, string telefone, int idade)
            : base(nome, email, telefone, idade)
        {
            Reservas = new List<Reserva>();
        }

        protected override int GerarId()
        {
            return GeradorId.GerarIdCliente();  
        }
    }
}
