// Autor: Tiago Vale
// Data: 10-11-2024
// Descrição: Enum que define os diferentes status de um Alojamento.

namespace GestaoAlojamentosApp.Domain.Enums
{
    public enum StatusAlojamento
    {
        // Alojamento está disponível para uma dada reserva.
        Disponivel,

        // Alojamento está indisponível para uma dada reserva.
        Indisponivel,

        // Alojamento está em manutenção, por tempo indefenido, e não pode ser reservado.
        EmManutencao
    }
}
