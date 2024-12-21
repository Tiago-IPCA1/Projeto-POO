namespace GestaoAlojamentosApp.Domain.Enums
{
    /// <summary>
    /// Enumeração que representa os diferentes métodos de pagamento disponíveis.
    /// Autor: Tiago Vale
    /// Email: a27675@alunos.ipca.pt
    /// Instituto: IPCA
    /// </summary>
    public enum MetodoPagamento
    {
        /// <summary>
        /// Pagamento realizado com cartão de crédito.
        /// </summary>
        CartaoCredito,

        /// <summary>
        /// Pagamento efetuado via transferência bancária.
        /// </summary>
        TransferenciaBancaria,

        /// <summary>
        /// Pagamento realizado através do PayPal.
        /// </summary>
        Paypal,

        /// <summary>
        /// Pagamento feito em dinheiro.
        /// </summary>
        Dinheiro,

        /// <summary>
        /// Pagamento realizado com cartão (débito ou outros).
        /// </summary>
        Cartao
    }
}
