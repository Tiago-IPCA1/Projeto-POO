using System;
using GestaoAlojamentosApp.Domain.Models;
using GestaoAlojamentosApp.Domain.Interfaces.Validators;
using GestaoAlojamentosApp.Domain.Interfaces.Repositories;
using GestaoAlojamentosApp.Domain.Enums;

namespace GestaoAlojamentosApp.Domain.Validators
{
    /// <summary>
    /// Classe respons�vel pela valida��o dos dados de pagamento
    /// Autor: Tiago Vale
    /// Email: a27675@alunos.ipca.pt
    /// Instituto: IPCA
    /// </summary>
    public class PagamentoValidator : IPagamentoValidator
    {

        private readonly IReservaRepository _reservaRepository;

        #region Construtor

        public PagamentoValidator(IReservaRepository reservaRepository)
        {
            _reservaRepository = reservaRepository ?? throw new ArgumentNullException(nameof(reservaRepository));
        }

        #endregion

        #region M�todos Valida��o

        public bool ValidarPagamento(Pagamento pagamento)
        {
            
            if (pagamento.Valor <= 0)
                throw new ArgumentException("O valor do pagamento deve ser maior que zero.");

            if (!Enum.IsDefined(typeof(StatusPagamento), pagamento.Status))
                throw new ArgumentException("Status de pagamento inv�lido.");

            var reserva = _reservaRepository.ObterPorId(pagamento.ReservaId);
            if (reserva == null)
                throw new KeyNotFoundException($"A reserva com ID {pagamento.ReservaId} n�o foi encontrada.");

            return true; 
        }

        #endregion
    }
}
