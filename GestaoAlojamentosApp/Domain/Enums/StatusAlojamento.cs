// Autor: Tiago Vale
// Data: 10-11-2024
// Descri��o: Enum que define os diferentes status de um Alojamento.

namespace GestaoAlojamentosApp.Domain.Enums
{
    public enum StatusAlojamento
    {
        // Alojamento est� dispon�vel para uma dada reserva.
        Disponivel,

        // Alojamento est� indispon�vel para uma dada reserva.
        Indisponivel,

        // Alojamento est� em manuten��o, por tempo indefenido, e n�o pode ser reservado.
        EmManutencao
    }
}
