// Autor: Tiago Vale
// Data: 10-11-2024
// Descrição: Enum que define os diferentes status de um Check-in.

namespace GestaoAlojamentosApp.Domain.Enums
{
    public enum StatusCheckIn
    {
        // Check-in ainda não foi realizado.
        Pendente,

        // Check-in foi confirmado.
        Confirmado,

        // Check-in foi cancelado.
        Cancelado
    }
}
