using System;
using System.Collections.Generic;
using GestaoAlojamentosApp.Domain.Models;
using GestaoAlojamentosApp.Domain.Interfaces.Repositories;
using GestaoAlojamentosApp.Domain.Interfaces.Validators;
using GestaoAlojamentosApp.Domain.Interfaces.Services;


namespace GestaoAlojamentosApp.App.Services
{
    /// <summary>
    /// Servi�o respons�vel pela l�gica de neg�cios relacionada ao processo de check-in.
    /// Implementa funcionalidades de cria��o, altera��o de status, remo��o e consulta de check-ins.
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

        #region M�todos de Cria��o e Atualiza��o

        public bool CriarCliente(string nome, string email, string telefone, int idade)
        {
            var clienteExistente = _clienteRepository.ObterClientesPorEmail(email);
            if (clienteExistente.Count > 0)
            {
                throw new ArgumentException("J� existe um cliente cadastrado com este email.");
            }

            var cliente = new Cliente(nome, email, telefone, idade);
            _clienteValidator.ValidarCliente(cliente);  // Usando o m�todo da interface
            _clienteRepository.Adicionar(cliente);
            return true;
        }

        public bool AtualizarCliente(int id, string nome, string email, string telefone, int idade)
        {
            var clienteExistente = _clienteRepository.ObterPorId(id);
            if (clienteExistente == null)
                throw new KeyNotFoundException($"Cliente com ID {id} n�o encontrado.");

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

            clienteExistente.Email = email; // Atualiza o email ap�s a valida��o
            _clienteRepository.Atualizar(clienteExistente);
            return true;
        }

        #endregion

        #region M�todos de Remo��o

        public bool RemoverCliente(int id)
        {
            var cliente = _clienteRepository.ObterPorId(id);
            if (cliente == null)
                throw new KeyNotFoundException($"Cliente com ID {id} n�o encontrado.");

            _clienteRepository.Remover(id);
            return true;
        }

        #endregion

        #region M�todos de Consulta

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
