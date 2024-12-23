using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GestaoAlojamentosApp.Domain.Enums
{
    /// <summary>
    /// Enumeração que representa os diferentes estados de pagamento.
    /// Autor: Tiago Vale
    /// Email: a27675@alunos.ipca.pt
    /// Instituto: IPCA
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]  // Converte o enum para string durante a serialização
    public enum StatusPagamento
    {
        /// <summary>
        /// Pagamento ainda não foi realizado e está pendente.
        /// </summary>
        Pendente,

        /// <summary>
        /// Pagamento foi concluído com sucesso.
        /// </summary>
        Confirmado,

        /// <summary>
        /// Pagamento foi cancelado ou devolvido.
        /// </summary>
        Cancelado
    }
}
