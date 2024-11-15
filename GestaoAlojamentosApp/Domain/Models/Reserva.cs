/* Autor: Tiago Vale
   Data: 15 de novembro de 2024
   Email: a27675@alunos.ipca.pt
   Descrição: Classe que representa a reserva de um alojamento por um cliente.
*/
using System;
using GestaoAlojamentosApp.Domain.Enums;
using GestaoAlojamentosApp.Domain.Utils;

namespace GestaoAlojamentosApp.Domain.Models
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
