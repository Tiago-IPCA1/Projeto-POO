namespace GestaoAlojamentosApp.Domain.Enums
{
    /// <summary>
    /// Enumera��o que representa os diferentes estados de um processo de check-in.
    /// Autor: Tiago Vale
    /// Email: a27675@alunos.ipca.pt
    /// Instituto: IPCA
    /// </summary>
    public enum StatusCheckIn
    {
        /// <summary>
        /// Check-in ainda n�o foi realizado e est� pendente.
        /// </summary>
        Pendente,

        /// <summary>
        /// Check-in foi realizado com sucesso.
        /// </summary>
        Realizado,

        /// <summary>
        /// Check-in foi cancelado.
        /// </summary>
        Cancelado
    }
}
