// Autor: Tiago Vale
// Data: 10-11-2024
// Descrição: Enum que define os diferentes status de um Pagamento.

namespace GestaoAlojamentosApp.Domain.Enums
{
    public enum StatusPagamento
    {
        // Pagamento ainda não foi realizado.
        Pendente,

        // Pagamento foi confirmado.
        Confirmado,

        // Pagamento foi cancelado.
        Cancelado
    }
}
