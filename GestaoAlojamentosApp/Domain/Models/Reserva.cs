using System;
using Newtonsoft.Json;
using GestaoAlojamentosApp.Domain.Enums;
using GestaoAlojamentosApp.Utils.CriarIds;

namespace GestaoAlojamentosApp.Domain.Models
{
    /// <summary>
    /// Classe que representa uma reserva, incluindo informações sobre o cliente, alojamento, datas, status, preço total e número de pessoas.
    /// Autor: Tiago Vale
    /// Email: a27675@alunos.ipca.pt
    /// Instituto: IPCA
    /// </summary>
    public class Reserva
    {
        public int Id { get; private set; }
        public int ClienteId { get; set; }
        public int AlojamentoId { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public StatusReserva Status { get; set; }
        public decimal PrecoTotal { get; set; }
        public int NumeroDePessoas { get; set; }

        /// <summary>
        /// Construtor da classe Reserva.
        /// </summary>
        /// <param name="clienteId">Id do cliente associado à reserva.</param>
        /// <param name="alojamentoId">Id do alojamento associado à reserva.</param>
        /// <param name="dataInicio">Data de início da reserva.</param>
        /// <param name="dataFim">Data de fim da reserva.</param>
        /// <param name="precoTotal">Preço total da reserva.</param>
        /// <param name="numeroDePessoas">Número de pessoas na reserva.</param>
        public Reserva(int clienteId, int alojamentoId, DateTime dataInicio, DateTime dataFim, decimal precoTotal, int numeroDePessoas)
        {
            Id = GeradorId.GerarIdReserva();
            ClienteId = clienteId;
            AlojamentoId = alojamentoId;
            DataInicio = dataInicio;
            DataFim = dataFim;
            Status = StatusReserva.Pendente;
            PrecoTotal = precoTotal;
            NumeroDePessoas = numeroDePessoas;
        }
    }
}
