/* @file: StatusReserva.cs
   @autor: Tiago Vale
   @data: 4 de novembro de 2024
   @email: a27675@alunos.ipca.pt
   @descrição: Enum que define os diferentes status de uma Reserva.
*/

namespace GestaoAlojamentosApp.Domain.Models.Enums
{
    public enum StatusReserva
    {
        // Reserva ainda não foi confirmada.
        Pendente,

        // Reserva foi confirmada.
        Confirmada,

        // Reserva foi cancelada.
        Cancelada
    }
}
