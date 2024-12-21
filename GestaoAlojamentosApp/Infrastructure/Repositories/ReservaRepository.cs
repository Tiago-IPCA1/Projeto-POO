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
    /// Repositório responsável pela gestão de reservas.
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

        #region Métodos de Consulta

        /// <summary>
        /// Obtém uma lista de reservas associadas a um cliente específico.
        /// </summary>
        public List<Reserva> ObterReservasPorCliente(int clienteId)
        {
            return _cache?.Where(r => r.ClienteId == clienteId).ToList() ?? new List<Reserva>();
        }

        /// <summary>
        /// Obtém uma lista de reservas associadas a um alojamento específico.
        /// </summary>
        public List<Reserva> ObterReservasPorAlojamento(int alojamentoId)
        {
            return _cache?.Where(r => r.AlojamentoId == alojamentoId).ToList() ?? new List<Reserva>();
        }

        /// <summary>
        /// Obtém uma lista de reservas disponíveis dentro de um intervalo de datas.
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
        /// Obtém uma lista de reservas com base em seu status atual.
        /// </summary>
        public List<Reserva> ObterPorStatus(StatusReserva status)
        {
            return _cache?.Where(r => r.Status == status).ToList() ?? new List<Reserva>();
        }

        #endregion

        #region Método de Atualização de Status

        /// <summary>
        /// Atualiza o status de uma reserva específica.
        /// </summary>
        public void AtualizarStatus(int id, StatusReserva status)
        {
            var reserva = ObterPorId(id);
            if (reserva != null)
            {
                reserva.Status = status;
                Atualizar(reserva); // Atualiza a reserva após a alteração de status
            }
            else
            {
                throw new InvalidOperationException("Reserva não encontrada para alteração de status.");
            }
        }

        #endregion

        #region Implementação do Método Abstrato

        /// <summary>
        /// Implementação do método abstrato para obter o ID de uma reserva.
        /// </summary>
        protected override object GetEntityId(Reserva entity)
        {
            return entity.Id; 
        }

        #endregion
    }
}
