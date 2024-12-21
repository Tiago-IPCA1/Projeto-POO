using System;
using System.Collections.Generic;
using System.IO;
using GestaoAlojamentosApp.Domain.Models;
using GestaoAlojamentosApp.Domain.Enums;
using GestaoAlojamentosApp.Domain.Interfaces.Repositories;
using System.Linq;

namespace GestaoAlojamentosApp.Infrastructure.Repositories
{
    /// <summary>
    /// Reposit�rio respons�vel pela gest�o de reservas.
    /// Autor: Tiago Vale
    /// Email: a27675@alunos.ipca.pt
    /// Instituto: IPCA
    /// </summary>
    public class ReservaRepository : RepositoryBase<Reserva>, IReservaRepository
    {
        // Construtor
        public ReservaRepository(string? filePath = null)
            : base(filePath ?? Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\Infrastructure\Database", "reservas.json"))
        {
        }

        #region M�todos de Consulta

        /// <summary>
        /// Obt�m uma lista de reservas associadas a um cliente espec�fico.
        /// </summary>
        public List<Reserva> ObterReservasPorCliente(int clienteId)
        {
            return _cache?.Where(r => r.ClienteId == clienteId).ToList() ?? new List<Reserva>();
        }

        /// <summary>
        /// Obt�m uma lista de reservas associadas a um alojamento espec�fico.
        /// </summary>
        public List<Reserva> ObterReservasPorAlojamento(int alojamentoId)
        {
            return _cache?.Where(r => r.AlojamentoId == alojamentoId).ToList() ?? new List<Reserva>();
        }

        /// <summary>
        /// Obt�m uma lista de reservas dispon�veis dentro de um intervalo de datas.
        /// </summary>
        public List<Reserva> ObterReservasDisponiveis(DateTime dataInicio, DateTime dataFim)
        {
            var reservasDisponiveis = new List<Reserva>();

            foreach (var reserva in _cache)
            {
                if (reserva.DataFim < dataInicio || reserva.DataInicio > dataFim)
                {
                    reservasDisponiveis.Add(reserva);
                }
            }

            return reservasDisponiveis;
        }

        /// <summary>
        /// Obt�m uma lista de reservas com base em seu status atual.
        /// </summary>
        public List<Reserva> ObterPorStatus(StatusReserva status)
        {
            return _cache?.Where(r => r.Status == status).ToList() ?? new List<Reserva>();
        }

        #endregion

        #region M�todo de Atualiza��o de Status

        /// <summary>
        /// Atualiza o status de uma reserva espec�fica.
        /// </summary>
        public void AtualizarStatus(int id, StatusReserva status)
        {
            var reserva = ObterPorId(id);
            if (reserva != null)
            {
                reserva.Status = status;
                Atualizar(reserva); // Atualiza a reserva ap�s a altera��o de status
            }
            else
            {
                throw new InvalidOperationException("Reserva n�o encontrada para altera��o de status.");
            }
        }

        #endregion

        #region Implementa��o do M�todo Abstrato

        /// <summary>
        /// Implementa��o do m�todo abstrato para obter o ID de uma reserva.
        /// </summary>
        protected override object GetEntityId(Reserva entity)
        {
            return entity.Id; 
        }

        #endregion
    }
}
