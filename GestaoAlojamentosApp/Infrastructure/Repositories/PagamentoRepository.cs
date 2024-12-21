using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GestaoAlojamentosApp.Domain.Models;
using GestaoAlojamentosApp.Domain.Interfaces.Repositories;
using GestaoAlojamentosApp.Domain.Enums;

namespace GestaoAlojamentosApp.Infrastructure.Repositories
{
    /// <summary>
    /// Repositório responsável pela gestão dos pagamentos.
    /// Autor: Tiago Vale
    /// Email: a27675@alunos.ipca.pt
    /// Instituto: IPCA
    /// </summary>
    public class PagamentoRepository : RepositoryBase<Pagamento>, IPagamentoRepository
    {
        private readonly IReservaRepository _reservaRepository; // Adiciona a dependência do repositório de reservas

        // Construtor
        public PagamentoRepository(IReservaRepository reservaRepository, string? filePath = null)
            : base(filePath ?? Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\Infrastructure\Database", "pagamentos.json"))
        {
            _reservaRepository = reservaRepository; // Injeta a dependência de IReservaRepository
        }

        #region Métodos de Consulta

        /// <summary>
        /// Procura pagamentos pelo ID da reserva.
        /// </summary>
        public List<Pagamento> ObterPagamentosPorReserva(int reservaId)
        {
            return _cache?.Where(p => p.ReservaId == reservaId).ToList() ?? new List<Pagamento>();
        }

        /// <summary>
        /// Procura pagamentos pelo ID do cliente associado à reserva.
        /// </summary>
        public List<Pagamento> ObterPagamentosPorCliente(int clienteId)
        {
            return _cache?.Where(p =>
            {
                var reserva = _reservaRepository.ObterPorId(p.ReservaId); // Usa o repositório injetado para obter a reserva
                return reserva != null && reserva.ClienteId == clienteId;
            }).ToList() ?? new List<Pagamento>();
        }

        /// <summary>
        /// Procura pagamentos pelo ID do alojamento associado à reserva.
        /// </summary>
        public List<Pagamento> ObterPagamentosPorAlojamento(int alojamentoId)
        {
            return _cache?.Where(p =>
            {
                var reserva = _reservaRepository.ObterPorId(p.ReservaId); // Usa o repositório injetado para obter a reserva
                return reserva != null && reserva.AlojamentoId == alojamentoId;
            }).ToList() ?? new List<Pagamento>();
        }

        /// <summary>
        /// Procura pagamentos por método de pagamento.
        /// </summary>
        public List<Pagamento> ObterPagamentosPorMetodo(MetodoPagamento metodoPagamento)
        {
            return _cache?.Where(p => p.MetodoPagamento == metodoPagamento).ToList() ?? new List<Pagamento>();
        }

        /// <summary>
        /// Procura pagamentos pelo status do pagamento.
        /// </summary>
        public List<Pagamento> ObterPagamentosPorStatus(StatusPagamento status)
        {
            return _cache?.Where(p => p.Status == status).ToList() ?? new List<Pagamento>();
        }

        #endregion

        #region Implementação do Método Abstrato

        // Implementação do método abstrato para obter o ID de um Pagamento
        protected override object GetEntityId(Pagamento entity)
        {
            return entity.Id; 
        }

        #endregion
    }
}
