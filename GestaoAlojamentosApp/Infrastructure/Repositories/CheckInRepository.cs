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
    /// Reposit�rio respons�vel pelo gest�o de check-ins.
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

        #region M�todos de Consulta

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

        #region M�todos de Atualiza��o de Status

        public void AtualizarStatus(int id, StatusCheckIn status)
        {
            var checkIn = ObterCheckInPorId(id);
            if (checkIn != null)
            {
                checkIn.Status = status;
                Atualizar(checkIn); // Atualiza o check-in ap�s a altera��o de status
            }
            else
            {
                throw new InvalidOperationException("Check-in n�o encontrado para altera��o de status.");
            }
        }

        #endregion

        #region M�todos de Verifica��o

        /// <summary>
        /// Verifica se j� existe um check-in para uma reserva.
        /// </summary>
        public bool CheckInJaExiste(int reservaId)
        {
            return _cache?.Any(c => c.ReservaId == reservaId) ?? false;
        }

        #endregion

        #region Implementa��o do M�todo Abstrato

        // Implementa��o do m�todo abstrato para obter o ID de um CheckIn
        protected override object GetEntityId(CheckIn entity)
        {
            return entity.Id; 
        }

        #endregion
    }
}
