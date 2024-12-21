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
    /// Reposit�rio respons�vel pela gest�o dos pagamentos.
    /// Autor: Tiago Vale
    /// Email: a27675@alunos.ipca.pt
    /// Instituto: IPCA
    /// </summary>
    public class PagamentoRepository : RepositoryBase<Pagamento>, IPagamentoRepository
    {
        private readonly IReservaRepository _reservaRepository; // Adiciona a depend�ncia do reposit�rio de reservas

        // Construtor
        public PagamentoRepository(IReservaRepository reservaRepository, string? filePath = null)
            : base(filePath ?? Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\Infrastructure\Database", "pagamentos.json"))
        {
            _reservaRepository = reservaRepository; // Injeta a depend�ncia de IReservaRepository
        }

        #region M�todos de Consulta

        /// <summary>
        /// Procura pagamentos pelo ID da reserva.
        /// </summary>
        public List<Pagamento> ObterPagamentosPorReserva(int reservaId)
        {
            return _cache?.Where(p => p.ReservaId == reservaId).ToList() ?? new List<Pagamento>();
        }

        /// <summary>
        /// Procura pagamentos pelo ID do cliente associado � reserva.
        /// </summary>
        public List<Pagamento> ObterPagamentosPorCliente(int clienteId)
        {
            return _cache?.Where(p =>
            {
                var reserva = _reservaRepository.ObterPorId(p.ReservaId); // Usa o reposit�rio injetado para obter a reserva
                return reserva != null && reserva.ClienteId == clienteId;
            }).ToList() ?? new List<Pagamento>();
        }

        /// <summary>
        /// Procura pagamentos pelo ID do alojamento associado � reserva.
        /// </summary>
        public List<Pagamento> ObterPagamentosPorAlojamento(int alojamentoId)
        {
            return _cache?.Where(p =>
            {
                var reserva = _reservaRepository.ObterPorId(p.ReservaId); // Usa o reposit�rio injetado para obter a reserva
                return reserva != null && reserva.AlojamentoId == alojamentoId;
            }).ToList() ?? new List<Pagamento>();
        }

        /// <summary>
        /// Procura pagamentos por m�todo de pagamento.
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

        #region Implementa��o do M�todo Abstrato

        // Implementa��o do m�todo abstrato para obter o ID de um Pagamento
        protected override object GetEntityId(Pagamento entity)
        {
            return entity.Id; 
        }

        #endregion
    }
}
