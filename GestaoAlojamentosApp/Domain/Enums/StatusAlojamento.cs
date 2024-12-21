using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GestaoAlojamentosApp.Domain.Enums
{
    /// <summary>
    /// Enumeração que define os estados possíveis de um alojamento no sistema.
    /// Autor: Tiago Vale
    /// Email: a27675@alunos.ipca.pt
    /// Instituto: IPCA
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]  // Converte o enum para string durante a serialização
    public enum StatusAlojamento
    {
        /// <summary>
        /// O alojamento está disponível para reservas e ocupação.
        /// </summary>
        Disponivel,

        /// <summary>
        /// O alojamento está temporariamente indisponível para reservas.
        /// </summary>
        Indisponivel,

        /// <summary>
        /// O alojamento está em manutenção ou reparação e não pode ser reservado.
        /// </summary>
        EmManutencao,
    }
}
