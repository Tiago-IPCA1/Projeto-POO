using System;
using GestaoAlojamentosApp.Domain.Models;

namespace GestaoAlojamentosApp.App.ViewModels
{
    /// <summary>
    /// Classe respons�vel por representar o modelo de dados de um cliente.
    /// Autor: Tiago Vale
    /// Email: a27675@alunos.ipca.pt
    /// Instituto: IPCA
    /// </summary>
    public class ClienteViewModel
    {
        #region Propriedades

        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty; 
        public string Email { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty; 
        public int Idade { get; set; }

        #endregion

        #region M�todos de Convers�o

        public static ClienteViewModel DeClienteParaViewModel(Cliente cliente)
        {
            if (cliente == null)
                throw new ArgumentNullException(nameof(cliente), "Cliente n�o pode ser nulo.");

            return new ClienteViewModel
            {
                Id = cliente.Id,
                Nome = cliente.Nome ?? string.Empty,
                Email = cliente.Email ?? string.Empty, 
                Telefone = cliente.Telefone ?? string.Empty, 
                Idade = cliente.Idade
            };
        }

        public Cliente ParaCliente()
        {
            if (string.IsNullOrEmpty(Nome) || string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Telefone))
                throw new ArgumentException("Nome, Email e Telefone n�o podem ser nulos ou vazios.");

            return new Cliente(Nome, Email, Telefone, Idade); // Usa o construtor com par�metros
        }
        #endregion
    }
}
