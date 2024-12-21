using Moq;
using System;
using System.Collections.Generic; 
using Xunit;
using GestaoAlojamentosApp.Domain.Models;
using GestaoAlojamentosApp.Domain.Interfaces.Repositories;
using GestaoAlojamentosApp.Domain.Interfaces.Validators;
using GestaoAlojamentosApp.App.Services;
using GestaoAlojamentosApp.Domain.Interfaces.Services;

namespace GestaoAlojamentosApp.Tests
{
    /// <summary>
    /// Classe responsável pelos testes unitários do serviço ClienteService.
    /// Autor: Tiago Vale
    /// Email: a27675@alunos.ipca.pt
    /// Instituto: IPCA
    /// </summary>
    public class ClienteServiceTests
    {
        private readonly Mock<IClienteRepository> _mockClienteRepository;
        private readonly Mock<IClienteValidator> _mockClienteValidator;
        private readonly IClienteService _clienteService;

        public ClienteServiceTests()
        {
            // Criação dos mocks para as dependências
            _mockClienteRepository = new Mock<IClienteRepository>();
            _mockClienteValidator = new Mock<IClienteValidator>();

            // Instancia o serviço com os mocks
            _clienteService = new ClienteService(
                _mockClienteRepository.Object,
                _mockClienteValidator.Object
            );
        }

        #region Testes de Criação

        [Fact]
        public void CriarCliente_Sucesso()
        {
            // Arrange
            var nome = "Cliente Teste";
            var email = "cliente@teste.com";
            var telefone = "123456789";
            var idade = 30;

            // Configura o mock para retornar uma lista vazia para o email
            _mockClienteRepository.Setup(r => r.ObterClientesPorEmail(email)).Returns(new List<Cliente>());

            // Configura o mock para a validação (não faz nada no mock)
            _mockClienteValidator.Setup(v => v.ValidarCliente(It.IsAny<Cliente>()));

            // Act
            var result = _clienteService.CriarCliente(nome, email, telefone, idade);

            // Assert
            _mockClienteValidator.Verify(v => v.ValidarCliente(It.IsAny<Cliente>()), Times.Once);
            _mockClienteRepository.Verify(r => r.Adicionar(It.IsAny<Cliente>()), Times.Once);
            Assert.True(result);
        }

        [Fact]
        public void CriarCliente_Excecao_Existe()
        {
            // Arrange
            var nome = "Cliente Teste";
            var email = "cliente@teste.com";
            var telefone = "123456789";
            var idade = 30;

            // Configura o mock para retornar um cliente existente com o mesmo email
            _mockClienteRepository.Setup(r => r.ObterClientesPorEmail(email)).Returns(new List<Cliente> { new Cliente(nome, email, telefone, idade) });

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _clienteService.CriarCliente(nome, email, telefone, idade));
        }

        #endregion

        #region Testes de Atualização

        [Fact]
        public void AtualizarCliente_Sucesso()
        {
            // Arrange
            var id = 1;
            var nome = "Cliente Atualizado";
            var email = "atualizado@teste.com";
            var telefone = "987654321";
            var idade = 35;

            var clienteExistente = new Cliente("Cliente Antigo", "antigo@teste.com", telefone, idade);

            // Configura o mock para retornar o cliente existente
            _mockClienteRepository.Setup(r => r.ObterPorId(id)).Returns(clienteExistente);
            _mockClienteValidator.Setup(v => v.ValidarCliente(It.IsAny<Cliente>()));

            // Act
            var result = _clienteService.AtualizarCliente(id, nome, email, telefone, idade);

            // Assert
            _mockClienteRepository.Verify(r => r.Atualizar(It.IsAny<Cliente>()), Times.Once);
            Assert.True(result);
            Assert.Equal(nome, clienteExistente.Nome);
        }

        [Fact]
        public void AtualizarCliente_Excecao_NaoExiste()
        {
            // Arrange
            var id = 999;
            var nome = "Cliente Atualizado";
            var email = "atualizado@teste.com";
            var telefone = "987654321";
            var idade = 35;

            // Configura o mock para retornar null (cliente não encontrado)
            _mockClienteRepository.Setup(r => r.ObterPorId(id)).Returns((Cliente?)null);

            // Act & Assert
            Assert.Throws<KeyNotFoundException>(() => _clienteService.AtualizarCliente(id, nome, email, telefone, idade));
        }

        #endregion

        #region Testes de Remoção

        [Fact]
        public void RemoverCliente_Sucesso()
        {
            // Arrange
            var id = 1;
            var clienteExistente = new Cliente("Cliente Teste", "cliente@teste.com", "123456789", 30);

            // Configura o mock para retornar o cliente existente
            _mockClienteRepository.Setup(r => r.ObterPorId(id)).Returns(clienteExistente);

            // Act
            var result = _clienteService.RemoverCliente(id);

            // Assert
            _mockClienteRepository.Verify(r => r.Remover(id), Times.Once);
            Assert.True(result);
        }

        [Fact]
        public void RemoverCliente_Excecao_NaoExiste()
        {
            // Arrange
            var id = 999; 

            // Configura o mock para retornar null
            _mockClienteRepository.Setup(r => r.ObterPorId(id)).Returns((Cliente?)null);

            // Act & Assert
            Assert.Throws<KeyNotFoundException>(() => _clienteService.RemoverCliente(id));
        }

        #endregion
    }
}
