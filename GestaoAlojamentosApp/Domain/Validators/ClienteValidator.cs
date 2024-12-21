using System;
using System.Text.RegularExpressions;
using GestaoAlojamentosApp.Domain.Models;
using GestaoAlojamentosApp.Domain.Interfaces.Validators;
using GestaoAlojamentosApp.Domain.Interfaces.Repositories;

namespace GestaoAlojamentosApp.Domain.Validators
{
    /// <summary>
    /// Classe responsável pela validação dos dados de cliente.
    /// Autor: Tiago Vale
    /// Email: a27675@alunos.ipca.pt
    /// Instituto: IPCA
    /// </summary>
    public class ClienteValidator : IClienteValidator
    {
        private readonly IClienteRepository _clienteRepository;

        #region Construtor

        public ClienteValidator(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository ?? throw new ArgumentNullException(nameof(clienteRepository));
        }

        #endregion

        #region Métodos de Validação

        public bool ValidarNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O nome do cliente não pode ser vazio.");
            return true;
        }

        public bool ValidarEmail(string email)
        {
            var regex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            if (string.IsNullOrWhiteSpace(email) || !regex.IsMatch(email))
                throw new ArgumentException("O email fornecido não é válido.");
            return true;
        }

        public bool ValidarTelefone(string telefone)
        {
            var regex = new Regex(@"^\d{9}$");
            if (string.IsNullOrWhiteSpace(telefone) || !regex.IsMatch(telefone))
                throw new ArgumentException("O telefone deve conter exatamente 9 dígitos.");
            return true;
        }

        public bool ValidarIdade(int idade)
        {
            if (idade < 18)
                throw new ArgumentException("A idade do cliente deve ser maior ou igual a 18.");
            return true;
        }

        public bool ValidarClienteExistenteParaCriacao(string email)
        {
            var clienteExistente = _clienteRepository.ObterClientesPorEmail(email);
            if (clienteExistente.Count > 0)
                throw new ArgumentException("Já existe um cliente registado com este email.");
            return true;
        }

        public bool ValidarClienteExistenteParaAtualizacao(string email, int id)
        {
            var clienteExistente = _clienteRepository.ObterClientesPorEmail(email);
            if (clienteExistente.Count > 0 && clienteExistente.FirstOrDefault()?.Id != id)
                throw new ArgumentException("Já existe um cliente registado com este email.");
            return true;
        }

        public bool ValidarCliente(Cliente cliente)
        {
            // Valida todas as propriedades do cliente
            ValidarNome(cliente.Nome);
            ValidarEmail(cliente.Email);
            ValidarTelefone(cliente.Telefone);
            ValidarIdade(cliente.Idade);
            return true;
        }

        #endregion
    }
}
