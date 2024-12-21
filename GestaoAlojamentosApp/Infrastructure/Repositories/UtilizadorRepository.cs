using GestaoAlojamentosApp.Domain.Models;
using GestaoAlojamentosApp.Domain.Interfaces.Repositories;
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace GestaoAlojamentosApp.Infrastructure.Repositories
{
    /// <summary>
    /// Reposit�rio respons�vel pela gest�o de utilizadores.
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

        #region M�todos de Consulta

        /// <summary>
        /// Obt�m um utilizador pelo ID.
        /// </summary>
        public Utilizador? ObterUtilizadorPorId(Guid id)
        {
            return ObterPorId(id);
        }

        /// <summary>
        /// Obt�m um utilizador pelo seu nome de utilizador.
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

        #region Implementa��o do M�todo Abstrato

        /// <summary>
        /// Obt�m o ID de um utilizador.
        /// </summary>
        protected override object GetEntityId(Utilizador entity)
        {
            return entity.Id;
        }

        #endregion
    }
}
