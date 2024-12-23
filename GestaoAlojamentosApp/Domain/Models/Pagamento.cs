using System;
using Newtonsoft.Json;
using GestaoAlojamentosApp.Domain.Enums;
using GestaoAlojamentosApp.Utils.CriarIds;

namespace GestaoAlojamentosApp.Domain.Models
{
    /// <summary>
    /// Classe que representa um pagamento realizado para uma reserva de alojamento.
    /// Contém informações sobre o valor pago, a data do pagamento, o método de pagamento e o status do pagamento.
    /// Autor: Tiago Vale
    /// Email: a27675@alunos.ipca.pt
    /// Instituto: IPCA
    /// </summary>
    public class Pagamento
    {
        public int Id { get; private set; }
        public int ReservaId { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataPagamento { get; set; }
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public MetodoPagamento MetodoPagamento { get; set; }
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public StatusPagamento Status { get; set; }

        /// <summary>
        /// Construtor da classe Pagamento.
        /// </summary>
        /// <param name="reservaId">Identificador da reserva associada ao pagamento.</param>
        /// <param name="valor">Valor total do pagamento realizado.</param>
        /// <param name="metodoPagamento">Método de pagamento utilizado.</param>
        /// <param name="status">Status atual do pagamento.</param>
        /// <param name="dataPagamento">Data em que o pagamento foi realizado.</param>
        public Pagamento(int reservaId, decimal valor, MetodoPagamento metodoPagamento, StatusPagamento status, DateTime dataPagamento)
        {
            Id = GeradorId.GerarIdPagamento(); 
            ReservaId = reservaId;
            Valor = valor;
            DataPagamento = dataPagamento; 
            MetodoPagamento = metodoPagamento;
            Status = status;
        }
    }
}
