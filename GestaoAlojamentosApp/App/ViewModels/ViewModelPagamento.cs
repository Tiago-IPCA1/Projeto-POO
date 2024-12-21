using System;
using GestaoAlojamentosApp.Domain.Enums;
using GestaoAlojamentosApp.Domain.Models;

namespace GestaoAlojamentosApp.App.ViewModels
{
    public class PagamentoViewModel
    {
        /// <summary>
        /// Classe respons�vel por representar o modelo de dados de um pagamento.
        /// Autor: Tiago Vale
        /// Email: a27675@alunos.ipca.pt
        /// Instituto: IPCA
        /// </summary>
        #region Propriedades

        public int Id { get; set; }
        public int ReservaId { get; set; }
        public decimal Valor { get; set; }
        public string MetodoPagamento { get; set; } = string.Empty;  // Inicializado com string.Empty
        public string StatusPagamento { get; set; } = string.Empty;  // Inicializado com string.Empty

        // Removido DataPagamentoFormatted
        public DateTime DataPagamento { get; set; }

        #endregion

        #region M�todos de Convers�o

        /// <summary>
        /// Converte um objeto Pagamento para o ViewModel PagamentoViewModel.
        /// </summary>
        public static PagamentoViewModel DePagamentoParaViewModel(Pagamento pagamento)
        {
            if (pagamento == null)
                throw new ArgumentNullException(nameof(pagamento), "Pagamento n�o pode ser nulo.");

            return new PagamentoViewModel
            {
                Id = pagamento.Id,
                ReservaId = pagamento.ReservaId,
                Valor = pagamento.Valor,
                DataPagamento = pagamento.DataPagamento,  
                MetodoPagamento = pagamento.MetodoPagamento.ToString(),
                StatusPagamento = pagamento.Status.ToString()  
            };
        }

        /// <summary>
        /// Converte o ViewModel PagamentoViewModel para um objeto Pagamento.
        /// </summary>
        public Pagamento ParaPagamento()
        {
            if (string.IsNullOrEmpty(MetodoPagamento) || string.IsNullOrEmpty(StatusPagamento))
                throw new ArgumentException("M�todo de pagamento e Status de pagamento n�o podem ser nulos ou vazios.");

            var metodoPagamento = (MetodoPagamento)Enum.Parse(typeof(MetodoPagamento), MetodoPagamento);
            var statusPagamento = (StatusPagamento)Enum.Parse(typeof(StatusPagamento), StatusPagamento);

            // Usando a data de pagamento selecionada do ViewModel
            return new Pagamento(ReservaId, Valor, metodoPagamento, statusPagamento, DataPagamento);
        }

        #endregion
    }
}
