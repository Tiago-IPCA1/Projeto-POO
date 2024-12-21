namespace GestaoAlojamentosApp.Domain.Enums
{
    /// <summary>
    /// Enumera��o que representa os diferentes m�todos de pagamento dispon�veis.
    /// Autor: Tiago Vale
    /// Email: a27675@alunos.ipca.pt
    /// Instituto: IPCA
    /// </summary>
    public enum MetodoPagamento
    {
        /// <summary>
        /// Pagamento realizado com cart�o de cr�dito.
        /// </summary>
        CartaoCredito,

        /// <summary>
        /// Pagamento efetuado via transfer�ncia banc�ria.
        /// </summary>
        TransferenciaBancaria,

        /// <summary>
        /// Pagamento realizado atrav�s do PayPal.
        /// </summary>
        Paypal,

        /// <summary>
        /// Pagamento feito em dinheiro.
        /// </summary>
        Dinheiro,

        /// <summary>
        /// Pagamento realizado com cart�o (d�bito ou outros).
        /// </summary>
        Cartao
    }
}
