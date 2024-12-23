namespace GestaoAlojamentosApp.Domain.Enums
{
    /// <summary>
    /// Enumeração que representa os diferentes estados de uma reserva.
    /// Autor: Tiago Vale
    /// Email: a27676@alunos.ipca.pt
    /// Instituto: IPCA
    /// </summary>
    public enum StatusReserva
    {
        /// <summary>
        /// A reserva foi criada, mas o pagamento ainda não foi confirmado.
        /// </summary>
        Pendente,

        /// <summary>
        /// Pagamento confirmado, reserva está confirmada.
        /// </summary>
        Confirmada,

        /// <summary>
        /// Reserva cancelada.
        /// </summary>
        Cancelada,

        /// <summary>
        /// A reserva foi concluída.
        /// </summary>
        Concluida
    }
}
