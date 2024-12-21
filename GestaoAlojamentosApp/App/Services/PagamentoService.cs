using System;
using System.Collections.Generic;
using GestaoAlojamentosApp.Domain.Models;
using GestaoAlojamentosApp.Domain.Interfaces.Repositories;
using GestaoAlojamentosApp.Domain.Interfaces.Validators;
using GestaoAlojamentosApp.Domain.Interfaces.Services;
using GestaoAlojamentosApp.Domain.Enums;

namespace GestaoAlojamentosApp.App.Services
{
    public class PagamentoService : IPagamentoService
    {
        private readonly IPagamentoRepository _pagamentoRepository;
        private readonly IReservaRepository _reservaRepository;
        private readonly IPagamentoValidator _pagamentoValidator;

        public PagamentoService(IPagamentoRepository pagamentoRepository, IReservaRepository reservaRepository, IPagamentoValidator pagamentoValidator)
        {
            _pagamentoRepository = pagamentoRepository ?? throw new ArgumentNullException(nameof(pagamentoRepository));
            _reservaRepository = reservaRepository ?? throw new ArgumentNullException(nameof(reservaRepository));
            _pagamentoValidator = pagamentoValidator ?? throw new ArgumentNullException(nameof(pagamentoValidator));
        }

        public bool CriarPagamento(int reservaId, decimal valor, MetodoPagamento metodoPagamento, StatusPagamento status, DateTime dataPagamento)
        {
            if (valor <= 0)
                throw new ArgumentException("O valor do pagamento deve ser maior que zero.");

            if (!Enum.IsDefined(typeof(StatusPagamento), status))
                throw new ArgumentException("Status de pagamento inválido.");

            var reserva = _reservaRepository.ObterPorId(reservaId);
            if (reserva == null)
                throw new KeyNotFoundException($"A reserva com ID {reservaId} não foi encontrada.");

            var pagamento = new Pagamento(reservaId, valor, metodoPagamento, status, dataPagamento);

            _pagamentoValidator.ValidarPagamento(pagamento);
            _pagamentoRepository.Adicionar(pagamento);

            return true;
        }

        public bool AdicionarPagamento(Pagamento pagamento)
        {
            if (pagamento == null) throw new ArgumentNullException(nameof(pagamento));

            _pagamentoValidator.ValidarPagamento(pagamento);
            _pagamentoRepository.Adicionar(pagamento);
            return true;
        }

        public bool RemoverPagamentoPorId(int id)
        {
            var pagamento = _pagamentoRepository.ObterPorId(id);
            if (pagamento == null)
                throw new KeyNotFoundException($"Pagamento com ID {id} não encontrado.");

            _pagamentoRepository.Remover(id);
            return true;
        }

        public List<Pagamento> ObterTodosPagamentos()
        {
            return _pagamentoRepository.ObterTodos();
        }

        public Pagamento? ObterPagamentoPorId(int id)
        {
            var pagamento = _pagamentoRepository.ObterPorId(id);
            if (pagamento == null)
            {
                throw new KeyNotFoundException($"Pagamento com ID {id} não encontrado.");
            }
            return pagamento;
        }

        public List<Pagamento> ObterPagamentosPorReserva(int reservaId)
        {
            return _pagamentoRepository.ObterPagamentosPorReserva(reservaId);
        }

        public List<Pagamento> ObterPagamentosPorCliente(int clienteId)
        {
            return _pagamentoRepository.ObterPagamentosPorCliente(clienteId);
        }

        public List<Pagamento> ObterPagamentosPorAlojamento(int alojamentoId)
        {
            return _pagamentoRepository.ObterPagamentosPorAlojamento(alojamentoId);
        }

        public List<Pagamento> ObterPagamentosPorMetodo(MetodoPagamento metodoPagamento)
        {
            return _pagamentoRepository.ObterPagamentosPorMetodo(metodoPagamento);
        }

        public List<Pagamento> ObterPagamentosPorStatus(StatusPagamento status)
        {
            return _pagamentoRepository.ObterPagamentosPorStatus(status);
        }

        public bool AlterarStatusPagamento(int id, StatusPagamento status)
        {
            var pagamento = _pagamentoRepository.ObterPorId(id);
            if (pagamento == null)
                throw new KeyNotFoundException($"Pagamento com ID {id} não encontrado.");

            pagamento.Status = status;
            _pagamentoRepository.Atualizar(pagamento);
            return true;
        }
    }
}
