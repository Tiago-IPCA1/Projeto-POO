// Autor: Tiago Vale
// Data: 10-11-2024
// Descrição: Enum que define os diferentes status de uma Reserva.

namespace GestaoAlojamentosApp.Domain.Enums
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
