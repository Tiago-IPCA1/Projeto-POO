using System;
using System.Collections.Generic;
using System.Linq;
using GestaoAlojamentosApp.Domain.Models;
using GestaoAlojamentosApp.Domain.Interfaces.Repositories;

namespace GestaoAlojamentosApp.Infrastructure.Repositories
{
    /// <summary>
    /// Repositório responsável pela gestão dos clientes.
    /// Autor: Tiago Vale
    /// Email: a27675@alunos.ipca.pt
    /// Instituto: IPCA
    /// </summary>
    public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
    {
        // Construtor
        public ClienteRepository(string? filePath = null)
            : base(filePath ?? System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\Infrastructure\Database", "clientes.json"))
        {
        }

        #region Métodos de Consulta Específicos

        /// <summary>
        /// Consulta de clientes pelo nome.
        /// </summary>
        public List<Cliente> ObterClientesPorNome(string nome)
        {
            return _cache?.Where(c => c.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase)).ToList() ?? new List<Cliente>();
        }

        /// <summary>
        /// Consulta de clientes pelo email.
        /// </summary>
        public List<Cliente> ObterClientesPorEmail(string email)
        {
            return _cache?.Where(c => c.Email.Equals(email, StringComparison.OrdinalIgnoreCase)).ToList() ?? new List<Cliente>();
        }

        #endregion

        #region Implementação do Método Abstrato

        // Implementação do método abstrato para obter o ID de um Cliente
        protected override object GetEntityId(Cliente entity)
        {
            return entity.Id; 
        }

        #endregion
    }
}
