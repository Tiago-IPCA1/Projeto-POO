using System;
using Newtonsoft.Json;
using GestaoAlojamentosApp.Domain.Enums;
using GestaoAlojamentosApp.Utils.CriarIds;


namespace GestaoAlojamentosApp.Domain.Models
{
    /// <summary>
    /// Classe que representa um check-in, contendo informações relacionadas à reserva, data e hora do check-in,
    /// número de clientes presentes, observações e status do check-in.
    /// Autor: Tiago Vale
    /// Email: a27675@alunos.ipca.pt
    /// Instituto: IPCA
    /// </summary>
    public class CheckIn
    {
        public int Id { get; private set; }
        public int ReservaId { get; set; }
        public DateTime DataHoraCheckIn { get; set; }
        public int NumeroDeClientesPresentes { get; set; }

        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public StatusCheckIn Status { get; set; }

        /// <summary>
        /// Construtor da classe CheckIn.
        /// </summary>
        /// <param name="reservaId">ID da reserva associada ao check-in.</param>
        /// <param name="dataHoraCheckIn">Data e hora do check-in.</param>
        /// <param name="numeroDeClientesPresentes">Número de clientes presentes no check-in.</param>
        public CheckIn(int reservaId, DateTime dataHoraCheckIn, int numeroDeClientesPresentes)
        {
            Id = GeradorId.GerarIdCheckIn();
            ReservaId = reservaId;
            DataHoraCheckIn = dataHoraCheckIn;
            NumeroDeClientesPresentes = numeroDeClientesPresentes;
            Status = StatusCheckIn.Pendente;
        }
    }
}
