/* @file: CheckIn.cs
   @autor: Tiago Vale
   @data: 5 de novembro de 2024
   @email: a27675@alunos.ipca.pt
   @descrição: Classe que representa o processo de check-in de uma reserva.
*/

using System;
using GestaoAlojamentosApp.Domain.Models.Enums;
using GestaoAlojamentosApp.Utils.CriarIds;

namespace GestaoAlojamentosApp.Domain.Models.Entities
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
