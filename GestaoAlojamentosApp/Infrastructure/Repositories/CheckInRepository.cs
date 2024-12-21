using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using GestaoAlojamentosApp.Domain.Models;
using GestaoAlojamentosApp.Domain.Interfaces.Repositories;
using GestaoAlojamentosApp.Domain.Enums;
using System.Linq;

namespace GestaoAlojamentosApp.Infrastructure.Repositories
{
    /// <summary>
    /// Repositório responsável pelo gestão de check-ins.
    /// Autor: Tiago Vale
    /// Email: a27675@alunos.ipca.pt
    /// Instituto: IPCA
    /// </summary>
    public class CheckInRepository : RepositoryBase<CheckIn>, ICheckInRepository
    {
        // Construtor
        public CheckInRepository(string? filePath = null)
            : base(filePath ?? Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\Infrastructure\Database", "checkins.json"))
        {
        }

        #region Métodos de Consulta

        public List<CheckIn> ObterCheckInsPorReserva(int reservaId)
        {
            return _cache?.Where(c => c.ReservaId == reservaId).ToList() ?? new List<CheckIn>();
        }

        public List<CheckIn> ObterCheckInsPorStatus(StatusCheckIn status)
        {
            return _cache?.Where(c => c.Status == status).ToList() ?? new List<CheckIn>();
        }

        public CheckIn? ObterCheckInPorId(int id)
        {
            return _cache?.FirstOrDefault(c => c.Id == id);
        }

        #endregion

        #region Métodos de Atualização de Status

        public void AtualizarStatus(int id, StatusCheckIn status)
        {
            var checkIn = ObterCheckInPorId(id);
            if (checkIn != null)
            {
                checkIn.Status = status;
                Atualizar(checkIn); // Atualiza o check-in após a alteração de status
            }
            else
            {
                throw new InvalidOperationException("Check-in não encontrado para alteração de status.");
            }
        }

        #endregion

        #region Métodos de Verificação

        /// <summary>
        /// Verifica se já existe um check-in para uma reserva.
        /// </summary>
        public bool CheckInJaExiste(int reservaId)
        {
            return _cache?.Any(c => c.ReservaId == reservaId) ?? false;
        }

        #endregion

        #region Implementação do Método Abstrato

        // Implementação do método abstrato para obter o ID de um CheckIn
        protected override object GetEntityId(CheckIn entity)
        {
            return entity.Id; 
        }

        #endregion
    }
}
