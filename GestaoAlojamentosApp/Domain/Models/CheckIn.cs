/* Autor: Tiago Vale
   Data: 15 de novembro de 2024
   Email: a27675@alunos.ipca.pt
   Descrição: Classe que representa o processo de check-in de uma reserva.
*/
using System;
using GestaoAlojamentosApp.Domain.Enums;
using GestaoAlojamentosApp.Domain.Utils;

namespace GestaoAlojamentosApp.Domain.Models
{
    public class CheckIn
    {
        #region Propriedades

        // Propriedades
        public int Id { get; private set; }
        public Reserva Reserva { get; private set; }
        public DateTime DataCheckIn { get; set; }
        public DateTime DataCheckOut { get; set; }
        public StatusCheckIn Status { get; private set; }

        #endregion

        #region Construtores

        // Construtor 
        public CheckIn(Reserva reserva, DateTime dataCheckIn, DateTime dataCheckOut)
        {
            Id = CriarIds.CriarNovoId();
            Reserva = reserva;
            DataCheckIn = dataCheckIn;
            DataCheckOut = dataCheckOut;
            Status = StatusCheckIn.Pendente; // Inicializa o Status como "Pendente"
        }

        #endregion
    }
}
