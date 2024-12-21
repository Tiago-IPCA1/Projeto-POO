using System;
using System.Collections.Generic;
using GestaoAlojamentosApp.Domain.Models;
using GestaoAlojamentosApp.Domain.Interfaces.Repositories;
using GestaoAlojamentosApp.Domain.Interfaces.Validators;
using GestaoAlojamentosApp.Domain.Interfaces.Services;


namespace GestaoAlojamentosApp.App.Services
{
    /// <summary>
    /// Serviço responsável pela lógica de negócios relacionada ao processo de check-in.
    /// Implementa funcionalidades de criação, alteração de status, remoção e consulta de check-ins.
    /// Autor: Tiago Vale
    /// Email: a27675@alunos.ipca.pt
    /// Instituto: IPCA
    /// </summary>
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IClienteValidator _clienteValidator;

        #region Construtor
        public ClienteService(IClienteRepository clienteRepository, IClienteValidator clienteValidator)
        {
            _clienteRepository = clienteRepository ?? throw new ArgumentNullException(nameof(clienteRepository));
            _clienteValidator = clienteValidator ?? throw new ArgumentNullException(nameof(clienteValidator));
        }
        #endregion

        #region Métodos de Criação e Atualização

        public bool CriarCliente(string nome, string email, string telefone, int idade)
        {
            var clienteExistente = _clienteRepository.ObterClientesPorEmail(email);
            if (clienteExistente.Count > 0)
            {
                throw new ArgumentException("Já existe um cliente cadastrado com este email.");
            }

            var cliente = new Cliente(nome, email, telefone, idade);
            _clienteValidator.ValidarCliente(cliente);  // Usando o método da interface
            _clienteRepository.Adicionar(cliente);
            return true;
        }

        public bool AtualizarCliente(int id, string nome, string email, string telefone, int idade)
        {
            var clienteExistente = _clienteRepository.ObterPorId(id);
            if (clienteExistente == null)
                throw new KeyNotFoundException($"Cliente com ID {id} não encontrado.");

            // Atualizar os dados do cliente
            clienteExistente.Nome = nome;
            clienteExistente.Telefone = telefone;
            clienteExistente.Idade = idade;

            // Se o email foi alterado, validar duplicidade
            if (clienteExistente.Email != email)
            {
                _clienteValidator.ValidarEmail(email);
                _clienteValidator.ValidarClienteExistenteParaAtualizacao(email, id);
            }

            clienteExistente.Email = email; // Atualiza o email após a validação
            _clienteRepository.Atualizar(clienteExistente);
            return true;
        }

        #endregion

        #region Métodos de Remoção

        public bool RemoverCliente(int id)
        {
            var cliente = _clienteRepository.ObterPorId(id);
            if (cliente == null)
                throw new KeyNotFoundException($"Cliente com ID {id} não encontrado.");

            _clienteRepository.Remover(id);
            return true;
        }

        #endregion

        #region Métodos de Consulta

        public Cliente? ObterClientePorId(int id)
        {
            return _clienteRepository.ObterPorId(id);
        }

        public List<Cliente> ObterTodosClientes()
        {
            return _clienteRepository.ObterTodos();
        }


        public List<Cliente> ObterClientesPorNome(string nome)
        {
            return _clienteRepository.ObterClientesPorNome(nome);
        }


        public List<Cliente> ObterClientesPorEmail(string email)
        {
            return _clienteRepository.ObterClientesPorEmail(email);
        }

        #endregion

    }
}
