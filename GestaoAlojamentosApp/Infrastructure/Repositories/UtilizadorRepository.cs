using GestaoAlojamentosApp.Domain.Models;
using GestaoAlojamentosApp.Domain.Interfaces.Repositories;
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace GestaoAlojamentosApp.Infrastructure.Repositories
{
    /// <summary>
    /// Repositório responsável pela gestão de utilizadores.
    /// Autor: Tiago Vale
    /// Email: a27675@alunos.ipca.pt
    /// Instituto: IPCA
    /// </summary>
    public class UtilizadorRepository : RepositoryBase<Utilizador>, IUtilizadorRepository
    {
        public UtilizadorRepository()
            : base(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\Infrastructure\Database", "utilizadores.json"))
        {
        }

        #region Métodos de Consulta

        /// <summary>
        /// Obtém um utilizador pelo ID.
        /// </summary>
        public Utilizador? ObterUtilizadorPorId(Guid id)
        {
            return ObterPorId(id);
        }

        /// <summary>
        /// Obtém um utilizador pelo seu nome de utilizador.
        /// </summary>
        public Utilizador? ObterUtilizadorPorUsername(string username)
        {
            return _cache.FirstOrDefault(u => u.Username == username);
        }

        /// <summary>
        /// Lista todos os utilizadores registados.
        /// </summary>
        public List<Utilizador> ListarTodosUtilizadores()
        {
            return _cache.ToList();
        }

        #endregion

        #region Implementação do Método Abstrato

        /// <summary>
        /// Obtém o ID de um utilizador.
        /// </summary>
        protected override object GetEntityId(Utilizador entity)
        {
            return entity.Id;
        }

        #endregion
    }
}
