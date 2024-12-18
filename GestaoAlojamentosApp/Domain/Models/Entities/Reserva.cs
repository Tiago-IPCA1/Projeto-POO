// @file: Reserva.cs
// @autor: Tiago Vale
// @data: 5 de novembro de 2024
// @email: a27675@alunos.ipca.pt
// @descrição: Classe que representa a reserva de um alojamento por um cliente.

using System;
using GestaoAlojamentosApp.Domain.Models.Enums;
using GestaoAlojamentosApp.Utils.CriarIds;

namespace GestaoAlojamentosApp.Domain.Models.Entities
{
    public class Reserva
    {
        #region Propriedades

        // Propriedades
        public int Id { get; private set; }
        public Alojamento Alojamento { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime DataReserva { get; set; }
        public DateTime DataCheckIn { get; set; }
        public DateTime DataCheckOut { get; set; }
        public StatusReserva Status { get; private set; }

        #endregion

        #region Construtores

        // Construtor 
        public Reserva(Alojamento alojamento, Cliente cliente, DateTime dataReserva, DateTime dataCheckIn, DateTime dataCheckOut)
        {
            Id = CriarIds.CriarNovoId();
            Alojamento = alojamento;
            Cliente = cliente;
            DataReserva = dataReserva;
            DataCheckIn = dataCheckIn;
            DataCheckOut = dataCheckOut;
            Status = StatusReserva.Pendente; // Inicializa o status como "Pendente"
        }

        #endregion
    }
}
