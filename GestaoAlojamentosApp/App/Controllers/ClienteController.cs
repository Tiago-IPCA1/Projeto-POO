using System;
using System.Collections.Generic;
using GestaoAlojamentosApp.App.ViewModels;
using GestaoAlojamentosApp.Domain.Interfaces.Services;

namespace GestaoAlojamentosApp.App.Controllers
{
    /// <summary>
    /// Controlador responsável pela gestão de clientes
    /// Autor: Tiago Vale
    /// Email: a27675@alunos.ipca.pt
    /// Instituto: IPCA
    /// </summary>
    public class ClienteController
    {
        #region Atributos

        private readonly IClienteService _clienteService;

        #endregion

        #region Construtor

        /// <summary>
        /// Inicializa o controlador de clientes com o serviço de cliente fornecido.
        /// </summary>
        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService ?? throw new ArgumentNullException(nameof(clienteService));
        }

        #endregion

        #region Métodos de Obtenção de Dados

        /// <summary>
        /// Obtém todos os clientes registrados.
        /// </summary>
        public List<ClienteViewModel> ObterTodosClientes()
        {
            try
            {
                var clientes = _clienteService.ObterTodosClientes();
                var clientesViewModel = new List<ClienteViewModel>();

                foreach (var cliente in clientes)
                {
                    clientesViewModel.Add(new ClienteViewModel
                    {
                        Id = cliente.Id,
                        Nome = cliente.Nome,
                        Email = cliente.Email,
                        Telefone = cliente.Telefone,
                        Idade = cliente.Idade
                    });
                }

                return clientesViewModel;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Erro ao obter todos os clientes: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Obtém um cliente pelo seu ID.
        /// </summary>
        public ClienteViewModel? ObterClientePorId(int id)
        {
            try
            {
                var cliente = _clienteService.ObterClientePorId(id);
                if (cliente == null)
                    return null;

                return new ClienteViewModel
                {
                    Id = cliente.Id,
                    Nome = cliente.Nome,
                    Email = cliente.Email,
                    Telefone = cliente.Telefone,
                    Idade = cliente.Idade
                };
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Erro ao obter cliente por ID: {ex.Message}", ex);
            }
        }

        #endregion

        #region Métodos de Criação, Atualização e Remoção

        /// <summary>
        /// Cria um novo cliente.
        /// </summary>
        public bool CriarCliente(string nome, string email, string telefone, int idade)
        {
            try
            {
                return _clienteService.CriarCliente(nome, email, telefone, idade);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Erro ao criar cliente: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Atualiza as informações de um cliente existente.
        /// </summary>
        public bool AtualizarCliente(int id, string nome, string email, string telefone, int idade)
        {
            try
            {
                return _clienteService.AtualizarCliente(id, nome, email, telefone, idade);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Erro ao atualizar cliente: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Remove um cliente pelo seu ID.
        /// </summary>
        public bool RemoverCliente(int id)
        {
            try
            {
                return _clienteService.RemoverCliente(id);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Erro ao remover cliente: {ex.Message}", ex);
            }
        }

        #endregion
    }
}
